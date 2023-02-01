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
    public async Task<ActionResult<IEnumerable<DoctorDto>>> GetAllDoctors()
    {
        var doctors = await _doctorService.GetAll();
        return Ok(doctors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DoctorDto>> GetDoctorById([FromRoute] int id)
    {
        var doctor = await _doctorService.GetById(id);
        return Ok(doctor);
    }

    [HttpPost]
    public async Task<IActionResult> AddDoctorAsync([FromBody] CreateDoctorDto dto)
    {
        if (!ModelState.IsValid) BadRequest(ModelState);
        var (doctorId, doctor) = await _doctorService.Create(dto);
        return Created($"/api/doctors/{doctorId}", doctor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDoctor([FromRoute] int id, [FromBody] UpdateDoctorDto dto)
    {
        if (!ModelState.IsValid) BadRequest(ModelState);
        await _doctorService.Update(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctorById([FromRoute] int id)
    {
        await _doctorService.Delete(id);
        return NoContent();
    }
}
