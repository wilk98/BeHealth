using BeHealthBackend.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BeHealthBackend.DataAccess.DbContexts
{
    public class BeHealthContext : DbContext
    {
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Clinic> Clinics { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
        public virtual DbSet<Referral> Referrals { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<WorkHours> WorkHours { get; set; }

        public BeHealthContext(DbContextOptions<BeHealthContext> options) : base(options)
        {
        }
        public BeHealthContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
