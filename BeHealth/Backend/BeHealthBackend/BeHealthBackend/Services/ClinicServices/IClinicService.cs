using BeHealthBackend.DTOs.ClinicDtoFolder;

namespace BeHealthBackend.Services.ClinicServices;
public interface IClinicService
{
    Task<IEnumerable<ClinicDto>> GetClinicAsync();
    Task<ClinicDto> GetIdAsync(int id);
    Task<IEnumerable<ClinicDoctorDto>> GetDoctorsAsync(int id);
    Task<(int, CreateClinicDto)> CreateAsync(CreateClinicDto dto);
    Task UpdateAsync(int id, UpdateClinicDto dto);
    Task DeleteAsync(int id);
}