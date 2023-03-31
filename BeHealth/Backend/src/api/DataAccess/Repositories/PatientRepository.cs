using BeHealthBackend.DataAccess.DbContexts;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using core;

namespace BeHealthBackend.DataAccess.Repositories;

public class PatientRepository : Repository<Patient>, IPatientRepository
{
    public PatientRepository(BeHealthContext context) : base(context)
    {
        DbSet = context.Patients;
    }
}
