using AutoMapper;
using BeHealthBackend.Configurations.Exceptions;
using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using BeHealthBackend.DTOs.PatientDtoFolder;

namespace BeHealthBackend.Services.PatientServices;
public class PatientService : IPatientService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PatientService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PatientDto>> GetPatientsAsync()
    {
        var patients = await _unitOfWork.PatientRepository
            .GetAllAsync(includeProperties: "Address");

        var patientsDto = _mapper.Map<List<PatientDto>>(patients);

        return patientsDto;
    }

    public async Task<PatientDto> GetIdAsync(int id)
    {
        var patient = await _unitOfWork.PatientRepository
            .GetAsync(p => p.Id == id, includeProperties: "Address");

        var patientDto = _mapper.Map<PatientDto>(patient);
        return patientDto;
    }

    public async Task<(int, CreatePatientDto)> CreateAsync(CreatePatientDto dto)
    {
        var patient = _mapper.Map<Patient>(dto);
        await _unitOfWork.PatientRepository.AddAsync(patient);
        await _unitOfWork.SaveAsync();
        return (patient.Id, _mapper.Map<CreatePatientDto>(patient));
    }

    public async Task UpdateAsync(int id, UpdatePatientDto dto)
    {
        var patient = await _unitOfWork.PatientRepository
            .GetAsync(id);

        if (patient is null)
        {
            throw new NotFoundApiException(nameof(PatientDto), id.ToString());
        }

        _mapper.Map(dto, patient);
        await _unitOfWork.SaveAsync();
    }

    public async Task Delete(int id)
    {
        var patient = await _unitOfWork.PatientRepository
            .GetAsync(id);

        if (patient is null)
        {
            throw new NotFoundApiException(nameof(PatientDto), id.ToString());
        }
        _unitOfWork.PatientRepository.Remove(patient);
        await _unitOfWork.SaveAsync();
    }
}
