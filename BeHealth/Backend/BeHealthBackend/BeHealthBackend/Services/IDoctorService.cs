using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DTOs;

namespace BeHealthBackend.Services;
public interface IDoctorService
{
    Task<IEnumerable<DoctorDto>> GetAll();
    Task<DoctorDto> GetById(int id);
    Task<Doctor> Create(CreateDoctorDto dto);
    Task<Doctor?> Update(int id, UpdateDoctorDto dto);
    Task<Doctor?> Delete(int id);
}

