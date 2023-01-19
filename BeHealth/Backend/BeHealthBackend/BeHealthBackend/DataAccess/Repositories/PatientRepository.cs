using BeHealthBackend.DataAccess.DbContexts;
using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using CityInfo.API.DataAccess.Repositories;

namespace BeHealthBackend.DataAccess.Repositories;

public class PatientRepository : Repository<Patient>, IPatientRepository
{
    public PatientRepository(BeHealthContext context) : base(context)
    {
    }
}
