using BeHealthBackend.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
        }
    }
}
