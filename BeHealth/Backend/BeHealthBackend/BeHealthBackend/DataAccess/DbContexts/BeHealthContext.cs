using BeHealthBackend.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeHealthBackend.DataAccess.DbContexts
{
    public class BeHealthContext : DbContext
    {
        public BeHealthContext(DbContextOptions<BeHealthContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            modelBuilder.Entity<Visit>().HasData(new Visit
            {
                Doctor = null,
                DoctorId = Guid.NewGuid(),
                Id = 1,
                Name = "Test visit",
                Patient = null,
                PatientId = Guid.NewGuid(),
                VisitDate = new DateTime()
            });
        }
    }
}
