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
                StartDate = new DateTimeOffset(v.VisitDate).ToUnixTimeSeconds(),
            }
        );

        return visitsDTO;
    }
}
