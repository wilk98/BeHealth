using BeHealthBackend.DTOs.AccountDtoFolder;
using BeHealthBackend.Services.DoctorServices;
using BeHealthBackend.Services.PatientServices;
using Microsoft.AspNetCore.Mvc;

namespace BeHealthBackend.Controllers;

[ApiController, Route("/api/account")]
public class AccountController : ControllerBase
{
    private readonly IDoctorService _doctorService;
    private readonly IPatientService _patientService;

    public AccountController(IDoctorService doctorService, IPatientService patientService)
    {
        _doctorService = doctorService;
        _patientService = patientService;
    }

    [HttpPost("doctor/register")]
    public async Task<IActionResult> AddDoctorAsync([FromBody] CreateDoctorDto dto)
    {
        var (doctorId, doctor) = await _doctorService.CreateAsync(dto);
        return Created($"/api/doctors/{doctorId}", doctor);
    }

    [HttpPost("doctor/login")]
    public IActionResult LoginDoctor([FromBody] LoginDto dto)
    {
        var token = _doctorService.GenerateJwt(dto);
        return Ok(token);
    }

    [HttpPut("doctor/{id}")]
    public async Task<IActionResult> UpdateDoctorAsync([FromRoute] int id, [FromBody] UpdateDoctorDto dto)
    {
        await _doctorService.UpdateAsync(id, dto, User);
        return NoContent();
    }

    [HttpDelete("doctor/{id}")]
    public async Task<IActionResult> DeleteDoctorByIdAsync([FromRoute] int id)
    {
        await _doctorService.DeleteAsync(id, User);
        return NoContent();
    }

    [HttpPost("patient/register")]
    public async Task<IActionResult> AddPatientAsync([FromBody] CreatePatientDto dto)
    {
        var (patientId, patient) = await _patientService.CreateAsync(dto);
        return Created($"/api/patients/{patientId}", patient);
    }

    [HttpPost("patient/login")]
    public IActionResult LoginPatient([FromBody] LoginDto dto)
    {
        var token = _patientService.GenerateJwt(dto);
        return Ok(token);
    }

    [HttpPut("patient/{id}")]
    public async Task<IActionResult> UpdatePatientAsync([FromRoute] int id, [FromBody] UpdatePatientDto dto)
    {
        await _patientService.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("patient/{id}")]
    public async Task<IActionResult> DeletePatientByIdAsync([FromRoute] int id)
    {
        await _patientService.DeleteAsync(id);
        return NoContent();
    }
}