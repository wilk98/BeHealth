using AutoMapper;
using BeHealthBackend.Configurations.Exceptions;
using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using BeHealthBackend.DTOs.DoctorDtoFolder;
using Microsoft.AspNetCore.Identity;

namespace BeHealthBackend.Services.DoctorServices;
public class DoctorService : IDoctorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher<Doctor> _passwordHasher;

    public DoctorService(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher<Doctor> passwordHasher)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    public async Task<IEnumerable<DoctorDto>> GetDoctorsAsync()
    {
        var doctors = await _unitOfWork.DoctorRepository
            .GetAllAsync(includeProperties: "Address");

        var doctorsDto = _mapper.Map<List<DoctorDto>>(doctors);

        return doctorsDto;
    }

    public async Task<IEnumerable<DoctorDto>> GetDoctorsBySpecializationAsync(string specialization)
    {
        var doctors = await _unitOfWork.DoctorRepository
            .GetAsync(d => d.Specialist == specialization, includeProperties: "Address");

        var doctorsDto = _mapper.Map<List<DoctorDto>>(doctors);

        return doctorsDto;
    }

    public async Task<DoctorDto> GetIdAsync(int id)
    {
        var doctor = await _unitOfWork.DoctorRepository
            .GetAsync(d => d.Id == id, includeProperties: "Address");

        if (doctor is null)
            throw new NotFoundApiException(nameof(DoctorDto), id.ToString());

        var doctorDto = _mapper.Map<DoctorDto>(doctor);

        return doctorDto;
    }

    public async Task<(int, CreateDoctorDto)> CreateAsync(CreateDoctorDto dto)
    {
        var doctor = _mapper.Map<Doctor>(dto);
        var hashedPassword = _passwordHasher.HashPassword(doctor, dto.PasswordHash);
        doctor.PasswordHash = hashedPassword;

        await _unitOfWork.DoctorRepository.AddAsync(doctor);
        await _unitOfWork.SaveAsync();

        return (doctor.Id, _mapper.Map<CreateDoctorDto>(doctor));
    }

    public async Task UpdateAsync(int id, UpdateDoctorDto dto)
    {
        var doctor = await _unitOfWork.DoctorRepository
            .GetAsync(id);

        if (doctor is null)
            throw new NotFoundApiException(nameof(DoctorDto), id.ToString());

        _mapper.Map(dto, doctor);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var doctor = await _unitOfWork.DoctorRepository
            .GetAsync(id);

        if (doctor is null)
            throw new NotFoundApiException(nameof(DoctorDto), id.ToString());
        
        _unitOfWork.DoctorRepository.Remove(doctor);
        await _unitOfWork.SaveAsync();
    }
}