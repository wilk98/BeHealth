using BeHealthBackend.DataAccess.DbContexts;
using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DataAccess.Repositories.Interfaces;

namespace BeHealthBackend.DataAccess.Repositories;

public class DoctorRepository : Repository<Doctor>, IDoctorRepository
{
    public DoctorRepository(BeHealthContext context) : base(context)
    {
    }
}
