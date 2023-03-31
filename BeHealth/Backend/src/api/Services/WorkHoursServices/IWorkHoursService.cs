using core;
using application.Dtos.WorkHoursDtoFolder;

namespace BeHealthBackend.Services.WorkHoursServices;

public interface IWorkHoursService
{
    Task<(int, CreateWorkHoursDto)> CreateAsync(CreateWorkHoursDto workHoursDto);
    Task<IEnumerable<WorkHoursDto>> GetWorkHoursByDoctorIdAsync(int id);
}
