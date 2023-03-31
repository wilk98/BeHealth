using BeHealthBackend.DataAccess.DbContexts;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using core;

namespace BeHealthBackend.DataAccess.Repositories;

public class DoctorRepository : Repository<Doctor>, IDoctorRepository
{
    public DoctorRepository(BeHealthContext context) : base(context)
    {
        DbSet = context.Doctors;
    }
}
