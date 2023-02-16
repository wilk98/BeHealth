using BeHealthBackend.DTOs.ClinicDtoFolder;
using BeHealthBackend.Services.ClinicServices;
using Microsoft.AspNetCore.Mvc;

namespace BeHealthBackend.Controllers;
[ApiController, Route("/api/clinics")]
public class ClinicController : ControllerBase
{
    private readonly IClinicService _clinicService;

    public ClinicController(IClinicService clinicService)
    {
        _clinicService = clinicService;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClinicDto>>> GetAllClinicsAsync()
    {
        var clinics = await _clinicService.GetClinicAsync();
        return Ok(clinics);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClinicDto>> GetClinicByIdAsync([FromRoute] int id)
    {
        var clinic = await _clinicService.GetIdAsync(id);
        return Ok(clinic);
    }

    [HttpGet("{id}/doctors")]
    public async Task<ActionResult<IEnumerable<ClinicDoctorDto>>> GetAllDoctorsAsync([FromRoute] int id)
    {
        var doctors = await _clinicService.GetDoctorsAsync(id);
        return Ok(doctors);
    }

    [HttpPost]
    public async Task<IActionResult> AddClinicAsync([FromBody] CreateClinicDto dto)
    {
        var (clinicId, clinic) = await _clinicService.CreateAsync(dto);
        return Created($"/api/clinics/{clinicId}", clinic);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClinicsAsync([FromRoute] int id, [FromBody] UpdateClinicDto dto)
    {
        await _clinicService.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClinicByIdAsync([FromRoute] int id)
    {
        await _clinicService.DeleteAsync(id);
        return NoContent();
    }
}