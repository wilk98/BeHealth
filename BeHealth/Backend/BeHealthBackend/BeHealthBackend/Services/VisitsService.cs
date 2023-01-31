using AutoMapper;
using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using BeHealthBackend.DTOs.Visit;

namespace BeHealthBackend.Services;

public class VisitsService : IVisitsService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public VisitsService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> AcceptVisit(int visitId)
    {
        var visit = await _unitOfWork.VisitRepository.GetAsync(visitId);
        if (visit == null) return false;

        visit.Confirmed = true;
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<Visit?> AddVisit(CreateVisitDto visitDto)
    {
        var visit = _mapper.Map<Visit>(visitDto);

        // TODO pull doctor's treatments and verify is treatment in visitDto one of availiable

        var patient = await _unitOfWork.PatientRepository.GetAsync(visit.PatientId);
        if (patient == null) return null;
        var doctor = await _unitOfWork.PatientRepository.GetAsync(visit.DoctorId);
        if (doctor == null) return null;

        await _unitOfWork.VisitRepository.AddAsync(visit);
        await _unitOfWork.SaveAsync();
        return visit;
    }

    public async Task<bool> DeclineVisit(int visitId)
    {
        var visit = await _unitOfWork.VisitRepository.GetAsync(visitId);
        if (visit == null) return false;

        visit.Confirmed = false;
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task DeleteVisit(int id)
    {
        var visit = await _unitOfWork.VisitRepository.GetAsync(id);
        if (visit == null) return;

        _unitOfWork.VisitRepository.Remove(visit);
        await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<VisitDTO>> GetVisitsByDoctorIdAsync(int id)
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

    public async Task<Visit?> PutVisit(int id, PutVisitDto visitDto)
    {
        var doctor = await _unitOfWork.DoctorRepository.GetAsync(visitDto.DoctorId);
        var patient = await _unitOfWork.DoctorRepository.GetAsync(visitDto.PatientId);
        if (doctor == null || patient == null) { return null; }

        var dbVisit = await _unitOfWork.VisitRepository.GetAsync(id);
        if (dbVisit == null) return null;

        dbVisit = _mapper.Map(visitDto, dbVisit);
        _unitOfWork.VisitRepository.SetModified(dbVisit);

        await _unitOfWork.SaveAsync();
        return dbVisit;
    }
}
