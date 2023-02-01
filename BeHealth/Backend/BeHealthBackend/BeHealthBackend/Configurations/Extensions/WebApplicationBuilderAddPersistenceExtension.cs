using BeHealthBackend.DataAccess.DbContexts;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using BeHealthBackend.DataAccess.Repositories;
using BeHealthBackend.Services.DoctorServices;
using BeHealthBackend.Services.PatientServices;
using BeHealthBackend.Services.VisitServices;
using CityInfo.API.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BeHealthBackend.Configurations.Extensions;
public static class WebApplicationBuilderAddPersistenceExtension
{
    public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<BeHealthContext>(
            option => option
                .UseSqlServer(builder.Configuration.GetConnectionString("BeHealthConnectionString")));

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<BeHealthContext, BeHealthContext>();
        builder.Services.AddScoped<IVisitRepository, VisitRepository>();
        builder.Services.AddScoped<IVisitsService, VisitsService>();
        builder.Services.AddScoped<IDoctorService, DoctorService>();
        builder.Services.AddScoped<IPatientService, PatientService>();

        return builder;
    }
}

