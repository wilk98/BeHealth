using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DTOs.VisitDtoFolder;

namespace BeHealthBackend.DataAccess.Repositories.Interfaces;

public interface IVisitRepository : IRepository<Visit>
{
    Task<IReadOnlyList<VisitCalendarDto>> GetVisitsForMonth(int doctorId, DateOnly date);
    Task<Visit?> GetDoctorVisitForDate(int doctorId, DateTime startDate, DateTime endDate);
    Task<Visit?> GetPatientVisitForDate(int patientId, DateTime startDate, DateTime endDate);
}
