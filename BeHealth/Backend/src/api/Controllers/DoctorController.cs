using BeHealthBackend.DTOs.DoctorDtoFolder;
using BeHealthBackend.Services.DoctorServices;
using Microsoft.AspNetCore.Mvc;
using BeHealthBackend.DTOs.ImageDto;
using BeHealthBackend.Services.FileServices;

namespace BeHealthBackend.Controllers;

[ApiController, Route("/api/doctors")]
public class DoctorController : ControllerBase
{
    private readonly IDoctorService _doctorService;
    private readonly IFileService _fileService;

    public DoctorController(IDoctorService doctorService, IFileService fileService)
    {
        _doctorService = doctorService;
        _fileService = fileService;
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
    [HttpPost("{id}/certificates")]
    public async Task<ActionResult> UploadCertificate([FromRoute] int id, [FromForm] CreateImageDto file)
    {
        var filename = await _fileService.SaveFile(file);
        var result = await _doctorService.AddCertificate(filename, id);
        return result ? Ok(filename) : BadRequest();
    }
    [HttpGet("{id}/certificates/")]
    public async Task<ActionResult> GetCertificates([FromRoute] int id)
    {
        var certificates = await _doctorService.GetCertificates(id);
        return certificates != null ? Ok(certificates) : BadRequest();
    }
}
