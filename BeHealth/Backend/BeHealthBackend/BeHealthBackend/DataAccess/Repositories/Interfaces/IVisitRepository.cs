using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DTOs.Visit;

namespace BeHealthBackend.DataAccess.Repositories.Interfaces;

public interface IVisitRepository : IRepository<Visit>
{
    Task<IReadOnlyList<VisitCalendarDto>> GetVisitsForMonth(int doctorId, DateOnly date);
}
