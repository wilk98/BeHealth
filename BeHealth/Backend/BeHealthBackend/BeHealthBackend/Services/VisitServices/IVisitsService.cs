using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DTOs.VisitDtoFolder;

namespace BeHealthBackend.Services.VisitServices;

public interface IVisitsService
{
    Task<bool> DeclineVisit(int visitId);
    Task<bool> AcceptVisit(int visitId);
    Task<IEnumerable<VisitDTO>> GetVisitsByDoctorIdAsync(int id);
    Task<Visit?> AddVisit(CreateVisitDto visitDto);
    Task<Visit?> PutVisit(int id, PutVisitDto visitDto);
    Task DeleteVisit(int id);
    Task<IEnumerable<VisitCalendarDto>> GetVisitsForMonth(int doctorId, DateOnly date);
}
