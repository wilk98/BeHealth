using AutoMapper;
using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using BeHealthBackend.DTOs;

namespace BeHealthBackend.Services;
public class DoctorService : IDoctorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DoctorService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DoctorDto>> GetAll()
    {
        var doctors = await _unitOfWork.DoctorRepository
            .GetAllAsync(includeProperties: "Address");

        var doctorsDtos = _mapper.Map<List<DoctorDto>>(doctors);

        return doctorsDtos;
    }

    public async Task<DoctorDto> GetById(int id)
    {
        var doctor = await _unitOfWork.DoctorRepository
            .GetAsync(d => d.Id == id, includeProperties: "Address");

        var doctorDto = _mapper.Map<DoctorDto>(doctor);
        return doctorDto;
    }

    public async Task<Doctor> Create(CreateDoctorDto dto)
    {
        var doctor = _mapper.Map<Doctor>(dto);
        await _unitOfWork.DoctorRepository.AddAsync(doctor);
        await _unitOfWork.SaveAsync();
        return doctor;
    }
}

