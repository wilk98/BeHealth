using AutoMapper;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using BeHealthBackend.Services.ReferralService;
using BeHealthBackend.DTOs.ReferralDtoFolder;

namespace BeHealthBackend.Services.ReferralsServices;
public class ReferralService : IReferralService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ReferralService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ReferralDto>> GetIdAsync(int id)
    {
       var referrals = await _unitOfWork.ReferralRepository
            .GetAllAsync(r => r.PatientId == id, includeProperties: "Patient");

        var referralsDto = referrals.Select(r => new ReferralDto
        {
            Id = r.Id,
            PatientId = r.PatientId,
            Patient = $"{r.Patient.FirstName} {r.Patient.LastName}",
            Date = new DateTimeOffset(r.Created).ToUnixTimeSeconds(),
            Specialist = r.Specialist,
            Description = r.Description,
            Code = r.Code,

        });

       return referralsDto;
    }
}
