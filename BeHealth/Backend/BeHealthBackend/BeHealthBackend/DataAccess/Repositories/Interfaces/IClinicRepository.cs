using BeHealthBackend.DataAccess.Entities;

namespace BeHealthBackend.DataAccess.Repositories.Interfaces;

public interface IClinicRepository : IRepository<Clinic>
{
    Task<List<Clinic>> GetByDoctorIdAsync(int doctorId);
}
