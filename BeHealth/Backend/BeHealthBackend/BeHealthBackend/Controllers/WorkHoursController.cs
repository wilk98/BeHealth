using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DTOs.VisitDtoFolder;
using BeHealthBackend.DTOs.WorkHoursDtoFolder;
using BeHealthBackend.Services.VisitServices;
using BeHealthBackend.Services.WorkHoursServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeHealthBackend.Controllers;

[ApiController, Route("/api/workhours")]
//[Authorize]

public class WorkHoursController : ControllerBase
{
    private readonly IWorkHoursService _workHoursService;

    public WorkHoursController(IWorkHoursService workHoursService)
    {
        _workHoursService = workHoursService;
    }

    [HttpGet("{doctorId}")]
    public async Task<IEnumerable<WorkHoursDto>> GetAllWorkHoursForDoctor([FromRoute] int doctorId)
    {
        var workHours = _workHoursService.GetWorkHoursByDoctorIdAsync(doctorId);
        return await workHours;
    }

    [HttpPost]
    public async Task<IActionResult> AddWorkHours([FromBody] CreateWorkHoursDto workHoursDto)
    {
        var (workHoursId, workHours) = await _workHoursService.CreateAsync(workHoursDto);
        return Created($"/api/workhours/{workHours.DoctorId}", workHours);

    }
}
