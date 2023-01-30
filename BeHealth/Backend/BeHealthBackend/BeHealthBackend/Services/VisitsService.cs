using BeHealthBackend.DataAccess.Repositories.Interfaces;
using BeHealthBackend.DTOs;

namespace BeHealthBackend.Services;

public class VisitsService : IVisitsService
{
    private readonly IUnitOfWork _unitOfWork;

    public VisitsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> AcceptVisit(int visitId)
    {
        var visit = await _unitOfWork.VisitRepository.GetAsync(visitId);
        if (visit == null) return false;

        visit.Confirmed = true;
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> DeclineVisit(int visitId)
    {
        var visit = await _unitOfWork.VisitRepository.GetAsync(visitId);
        if (visit == null) return false;

        visit.Confirmed = false;
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<IEnumerable<VisitDTO>> GetVisitsByDoctorIdAsync(Guid id)
    {
        var visits = await _unitOfWork.VisitRepository.GetAllAsync(
            filter: v => v.DoctorId.Equals(id),
            orderBy: visits => visits.OrderBy(v => v.VisitDate),
            includeProperties: "Patient");

        var visitsDTO = visits.Select(v => new VisitDTO {
                Id = v.Id,
                Duration = v.Duration,
                PatientId = v.PatientId,
                Patient = $"{v.Patient.FirstName} {v.Patient.LastName}",
                Treatment = v.Name,
                Confirmed = v.Confirmed,
                StartDate = new DateTimeOffset(v.VisitDate).ToUnixTimeSeconds(),
            }
        );

        return visitsDTO;
    }
}
