using BeHealthBackend.DTOs.PatientDtoFolder;
using BeHealthBackend.Services.PatientServices;
using Microsoft.AspNetCore.Mvc;

namespace BeHealthBackend.Controllers;

[ApiController, Route("/api/patients")]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PatientDto>>> GetAllPatientsAsync()
    {
        var patients = await _patientService.GetPatientsAsync();
        return Ok(patients);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PatientDto>> GetPatientByIdAsync([FromRoute] int id)
    {
        var patient = await _patientService.GetIdAsync(id);
        return Ok(patient);
    }

    [HttpPost]
    public async Task<IActionResult> AddPatientAsync([FromBody] CreatePatientDto dto)
    {
        var (patientId, patient) = await _patientService.CreateAsync(dto);
        return Created($"/api/patients/{patientId}", patient);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePatientAsync([FromRoute] int id, [FromBody] UpdatePatientDto dto)
    {
        await _patientService.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatientByIdAsync([FromRoute] int id)
    {
        await _patientService.DeleteAsync(id);
        return NoContent();
    }
}
