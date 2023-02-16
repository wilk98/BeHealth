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
        return Ok(doctors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DoctorDto>> GetDoctorByIdAsync([FromRoute] int id)
    {
        var doctor = await _doctorService.GetIdAsync(id);
        return Ok(doctor);
    }

    [HttpPost]
    public async Task<IActionResult> AddDoctorAsync([FromBody] CreateDoctorDto dto)
    {
        var (doctorId, doctor) = await _doctorService.CreateAsync(dto);
        return Created($"/api/doctors/{doctorId}", doctor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDoctorAsync([FromRoute] int id, [FromBody] UpdateDoctorDto dto)
    {
        await _doctorService.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctorByIdAsync([FromRoute] int id)
    {
        await _doctorService.DeleteAsync(id);
        return NoContent();
    }
}
