using AutoMapper;
using BeHealthBackend.Configurations.Exceptions;
using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using BeHealthBackend.DTOs.ClinicDtoFolder;

namespace BeHealthBackend.Services.ClinicServices;
public class ClinicService : IClinicService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClinicService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ClinicDto>> GetClinicAsync()
    {
        var clinics = await _unitOfWork.ClinicRepository
            .GetAllAsync(includeProperties: "Address");

        var clinicsDto = _mapper.Map<List<ClinicDto>>(clinics);

        return clinicsDto;
    }

    public async Task<ClinicDto> GetIdAsync(int id)
    {
        var clinic = await _unitOfWork.ClinicRepository
            .GetAsync(c => c.Id == id, includeProperties: "Address");

        if (clinic is null)
            throw new NotFoundApiException(nameof(ClinicDto), id.ToString());

        var clinicDto = _mapper.Map<ClinicDto>(clinic);

        return clinicDto;
    }

    public async Task<IEnumerable<ClinicDoctorDto>> GetDoctorsAsync(int id)
    {
        var doctors = await _unitOfWork.ClinicRepository
            .GetAllAsync(c => c.Id == id, includeProperties: "Doctors");

        var doctorsDto = _mapper.Map<List<ClinicDoctorDto>>(doctors);

        return doctorsDto;
    }

    public async Task<(int, CreateClinicDto)> CreateAsync(CreateClinicDto dto)
    {
        var clinic = _mapper.Map<Clinic>(dto);

        await _unitOfWork.ClinicRepository.AddAsync(clinic);
        await _unitOfWork.SaveAsync();

        return (clinic.Id, _mapper.Map<CreateClinicDto>(clinic));
    }

    public async Task UpdateAsync(int id, UpdateClinicDto dto)
    {
        var clinic = await _unitOfWork.ClinicRepository
            .GetAsync(id);

        if (clinic is null)
            throw new NotFoundApiException(nameof(ClinicDto), id.ToString());

        _mapper.Map(dto, clinic);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var clinic = await _unitOfWork.ClinicRepository
            .GetAsync(id);

        if (clinic is null)
            throw new NotFoundApiException(nameof(ClinicDto), id.ToString());

        _unitOfWork.ClinicRepository.Remove(clinic);
        await _unitOfWork.SaveAsync();
    }
}