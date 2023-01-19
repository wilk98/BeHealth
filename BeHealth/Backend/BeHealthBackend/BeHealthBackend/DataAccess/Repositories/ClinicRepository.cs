using BeHealthBackend.DataAccess.DbContexts;
using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using CityInfo.API.DataAccess.Repositories;

namespace BeHealthBackend.DataAccess.Repositories;

public class ClinicRepository : Repository<Clinic>, IClinicRepository
{
    public ClinicRepository(BeHealthContext context) : base(context)
    {
    }
}
