using BeHealthBackend.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using BeHealthBackend.Configurations.Extensions;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddLogger();
builder.AddPersistence();
builder.AddAuthentication();
builder.AddAuthorization();
builder.AddMapper();
builder.AddErrorHandler();
builder.AddSwaggerGen();

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddFluentValidation();
builder.Services.AddEndpointsApiExplorer();

builder.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseErrorHandler();
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseCors();
app.MapControllers();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<BeHealthContext>();
var pendingMigrations = dbContext.Database.GetPendingMigrations();

if (pendingMigrations.Any())
{
    dbContext.Database.Migrate();
}

app.Run();
