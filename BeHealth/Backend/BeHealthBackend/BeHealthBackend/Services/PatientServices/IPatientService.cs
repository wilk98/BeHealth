using BeHealthBackend.DTOs.AccountDtoFolder;
using BeHealthBackend.DTOs.PatientDtoFolder;

namespace BeHealthBackend.Services.PatientServices;
public interface IPatientService
{
    Task<IEnumerable<PatientDto>> GetPatientsAsync();
    Task<PatientDto> GetIdAsync(int id);
    Task<(int, CreatePatientDto)> CreateAsync(CreatePatientDto dto);
    Task UpdateAsync(int id, UpdatePatientDto dto);
    Task DeleteAsync(int id);
    string GenerateJwt(LoginDto dto);
}