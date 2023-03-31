using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DTOs.WorkHoursDtoFolder;


namespace BeHealthBackend.Services.WorkHoursServices;

public interface IWorkHoursService
{
    Task<(int, CreateWorkHoursDto)> CreateAsync(CreateWorkHoursDto workHoursDto);
    Task<IEnumerable<WorkHoursDto>> GetWorkHoursByDoctorIdAsync(int id);
}
