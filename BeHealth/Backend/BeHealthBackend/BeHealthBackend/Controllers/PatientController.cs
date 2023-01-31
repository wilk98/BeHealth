using BeHealthBackend.DTOs.Patient;
using BeHealthBackend.Services.Patient;
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
    public async Task<ActionResult<IEnumerable<PatientDto>>> GetAllPatients()
    {
        var patients = await _patientService.GetAll();
        return Ok(patients);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PatientDto>> GetPatientById([FromRoute] int id)
    {
        var patient = await _patientService.GetById(id);
        return Ok(patient);
    }

    [HttpPost]
    public async Task<IActionResult> AddPatientAsync([FromBody] CreatePatientDto dto)
    {
        if (!ModelState.IsValid) BadRequest(ModelState);
        var (patientId, patient) = await _patientService.Create(dto);
        return Created($"/api/patients/{patientId}", patient);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePatient([FromRoute] int id, [FromBody] UpdatePatientDto dto)
    {
        if (!ModelState.IsValid) BadRequest(ModelState);
        await _patientService.Update(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatientById([FromRoute] int id)
    {
        await _patientService.Delete(id);
        return NoContent();
    }
}
