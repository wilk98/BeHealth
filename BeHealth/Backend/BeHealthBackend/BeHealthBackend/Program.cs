using BeHealthBackend.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BeHealthContext>(
    option => option
        .UseSqlServer(builder.Configuration.GetConnectionString("BeHeathConnectionString")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<BeHealthContext>();
var pendingMigrations = dbContext.Database.GetPendingMigrations();

if (pendingMigrations.Any())
{
    dbContext.Database.Migrate();
}

app.Run();
