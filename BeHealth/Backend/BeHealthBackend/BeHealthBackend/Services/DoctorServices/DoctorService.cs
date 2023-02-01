using AutoMapper;
using BeHealthBackend.Configurations.Exceptions;
using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using BeHealthBackend.DTOs.DoctorDtoFolder;

namespace BeHealthBackend.Services.DoctorServices;
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

        var doctorsDto = _mapper.Map<List<DoctorDto>>(doctors);

        return doctorsDto;
    }

    public async Task<DoctorDto> GetById(int id)
    {
        var doctor = await _unitOfWork.DoctorRepository
            .GetAsync(d => d.Id == id, includeProperties: "Address");

        if (doctor is null)
            throw new NotFoundApiException(nameof(DoctorDto), id.ToString());

        var doctorDto = _mapper.Map<DoctorDto>(doctor);
        return doctorDto;
    }

    public async Task<(int, CreateDoctorDto)> Create(CreateDoctorDto dto)
    {
        var doctor = _mapper.Map<Doctor>(dto);
        await _unitOfWork.DoctorRepository.AddAsync(doctor);
        await _unitOfWork.SaveAsync();
        return (doctor.Id, _mapper.Map<CreateDoctorDto>(doctor));
    }

    public async Task Update(int id, UpdateDoctorDto dto)
    {
        var doctor = await _unitOfWork.DoctorRepository
            .GetAsync(id);

        if (doctor is null)
            throw new NotFoundApiException(nameof(DoctorDto), id.ToString());

        _mapper.Map(dto, doctor);
        await _unitOfWork.SaveAsync();
    }

    public async Task Delete(int id)
    {
        var doctor = await _unitOfWork.DoctorRepository
            .GetAsync(id);

        if (doctor is null)
            throw new NotFoundApiException(nameof(DoctorDto), id.ToString());
        
        _unitOfWork.DoctorRepository.Remove(doctor);
        await _unitOfWork.SaveAsync();
    }
}
