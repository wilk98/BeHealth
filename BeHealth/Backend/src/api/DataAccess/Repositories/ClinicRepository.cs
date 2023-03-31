using BeHealthBackend.DataAccess.DbContexts;
using core;
using BeHealthBackend.DataAccess.Repositories.Interfaces;

namespace BeHealthBackend.DataAccess.Repositories;

public class ClinicRepository : Repository<Clinic>, IClinicRepository
{
    public ClinicRepository(BeHealthContext context) : base(context)
    {
        DbSet = context.Clinics;
    }
}
