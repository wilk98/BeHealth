using BeHealthBackend.DTOs.Patient;

namespace BeHealthBackend.Services.Patient
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDto>> GetAll();
        Task<PatientDto> GetById(int id);
        Task<(int, CreatePatientDto)> Create(CreatePatientDto dto);
        Task Update(int id, UpdatePatientDto dto);
        Task Delete(int id);
    }
}
