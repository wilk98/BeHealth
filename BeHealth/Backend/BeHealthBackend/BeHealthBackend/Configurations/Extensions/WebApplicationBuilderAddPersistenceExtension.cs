using System.Text;
using BeHealthBackend.DataAccess.DbContexts;
using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using BeHealthBackend.DataAccess.Repositories;
using BeHealthBackend.Services.ClinicServices;
using BeHealthBackend.Services.DoctorServices;
using BeHealthBackend.Services.PatientServices;
using BeHealthBackend.Services.VisitServices;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BeHealthBackend.DataAccess.Entities.Validators;
using Microsoft.IdentityModel.Tokens;
using BeHealthBackend.DTOs.AccountDtoFolder;
using Microsoft.AspNetCore.Authorization;
using BeHealthBackend.Authorization;

namespace BeHealthBackend.Configurations.Extensions;
public static class WebApplicationBuilderAddPersistenceExtension
{
    public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<BeHealthContext>(
            option => option
                .UseSqlServer(builder.Configuration.GetConnectionString("BeHealthConnectionString")));

        var authenticationSettings = new AuthenticationSettings();

        builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);

        builder.Services.AddSingleton(authenticationSettings);
        builder.Services.AddAuthentication(option =>
        {
            option.DefaultAuthenticateScheme = "Bearer";
            option.DefaultScheme = "Bearer";
            option.DefaultChallengeScheme = "Bearer";
        }).AddJwtBearer(cfg =>
        {
            cfg.RequireHttpsMetadata = false;
            cfg.SaveToken = true;
            cfg.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = authenticationSettings.JwtIssuer,
                ValidAudience = authenticationSettings.JwtIssuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
            };
        });

        builder.Services.AddScoped<IAuthorizationHandler, DoctorResourceOperationRequirementHandler>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<BeHealthContext, BeHealthContext>();
        builder.Services.AddScoped<IVisitRepository, VisitRepository>();
        builder.Services.AddScoped<IVisitsService, VisitsService>();
        builder.Services.AddScoped<IDoctorService, DoctorService>();
        builder.Services.AddScoped<IPatientService, PatientService>();
        builder.Services.AddScoped<IClinicService, ClinicService>();
        builder.Services.AddScoped<IPasswordHasher<Doctor>, PasswordHasher<Doctor>>();
        builder.Services.AddScoped<IPasswordHasher<Patient>, PasswordHasher<Patient>>();
        builder.Services.AddScoped<IValidator<CreateDoctorDto>, CreateDoctorDtoValidator>();

        return builder;
    }
}

