using BeHealthBackend.DTOs.Doctor;

namespace BeHealthBackend.Services.Doctor;
public interface IDoctorService
{
    Task<IEnumerable<DoctorDto>> GetAll();
    Task<DoctorDto> GetById(int id);
    Task<(int, CreateDoctorDto)> Create(CreateDoctorDto dto);
    Task Update(int id, UpdateDoctorDto dto);
    Task Delete(int id);
}

