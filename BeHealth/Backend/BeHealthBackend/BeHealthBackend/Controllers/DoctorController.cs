using BeHealthBackend.DTOs.DoctorDtoFolder;
using BeHealthBackend.Services.DoctorServices;
using Microsoft.AspNetCore.Mvc;

namespace BeHealthBackend.Controllers;

[ApiController, Route("/api/doctors")]
public class DoctorController : ControllerBase
{
    private readonly IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DoctorDto>>> GetAllDoctorsAsync()
    {
        var doctors = await _doctorService.GetDoctorsAsync();
        Console.WriteLine(doctors.ToString());
        return Ok(doctors);
    }

    [HttpGet("search/{specialization}")]
    public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctorsBySpecializationAsync([FromRoute] string specialization)
    {
        var doctors = await _doctorService.GetDoctorsBySpecializationAsync(specialization);
        return Ok(doctors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DoctorDto>> GetDoctorByIdAsync([FromRoute] int id)
    {
        var doctor = await _doctorService.GetIdAsync(id);
        return Ok(doctor);
    }
}
