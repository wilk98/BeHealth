using AutoMapper;
using BeHealthBackend.Configurations.Exceptions;
using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using BeHealthBackend.DTOs.PatientDtoFolder;
using Microsoft.AspNetCore.Identity;
using System.Numerics;

namespace BeHealthBackend.Services.PatientServices;
public class PatientService : IPatientService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher<Patient> _passwordHasher;

    public PatientService(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher<Patient> passwordHasher)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
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
        var hashedPassword = _passwordHasher.HashPassword(patient, dto.PasswordHash);
        patient.PasswordHash = hashedPassword;

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

    public async Task DeleteAsync(int id)
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
