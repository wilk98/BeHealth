using BeHealthBackend.DTOs;

namespace BeHealthBackend.Services;

public interface IVisitsService
{
    Task<IEnumerable<VisitDTO>> GetVisitsByDoctorIdAsync(Guid id);
}
