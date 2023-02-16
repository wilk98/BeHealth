using BeHealthBackend.DTOs.DoctorDtoFolder;

namespace BeHealthBackend.Services.DoctorServices;
public interface IDoctorService
{
    Task<IEnumerable<DoctorDto>> GetDoctorsAsync();
    Task<DoctorDto> GetIdAsync(int id);
    Task<(int, CreateDoctorDto)> CreateAsync(CreateDoctorDto dto);
    Task UpdateAsync(int id, UpdateDoctorDto dto);
    Task DeleteAsync(int id);
}