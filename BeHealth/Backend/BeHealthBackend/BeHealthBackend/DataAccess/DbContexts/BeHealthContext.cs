using BeHealthBackend.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BeHealthBackend.DataAccess.DbContexts
{
    public class BeHealthContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Referral> Referrals { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        public BeHealthContext(DbContextOptions<BeHealthContext> options) : base(options)
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
