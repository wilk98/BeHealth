using BeHealthBackend.DTOs;

namespace BeHealthBackend.Services;

public interface IVisitsService
{
    Task<bool> DeclineVisit(int visitId);
    Task<bool> AcceptVisit(int visitId);
    Task<IEnumerable<VisitDTO>> GetVisitsByDoctorIdAsync(Guid id);
}
