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
}
