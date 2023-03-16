using BeHealthBackend.DTOs.AccountDtoFolder;
using BeHealthBackend.DTOs.DoctorDtoFolder;
using System.Security.Claims;

namespace BeHealthBackend.Services.DoctorServices;
public interface IDoctorService
{
    Task<IEnumerable<DoctorDto>> GetDoctorsAsync();
    Task<IEnumerable<DoctorDto>> GetDoctorsBySpecializationAsync(string specialization);
    Task<DoctorDto> GetIdAsync(int id);
    Task<(int, CreateDoctorDto)> CreateAsync(CreateDoctorDto dto);
    Task UpdateAsync(int id, UpdateDoctorDto dto, ClaimsPrincipal user);
    Task DeleteAsync(int id, ClaimsPrincipal user);
    string GenerateJwt(LoginDto dto);
    Task<IEnumerable<string>?> GetCertificates(int id);
    Task<bool> AddCertificate(string filename, int id);
}