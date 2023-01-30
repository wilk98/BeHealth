using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DTOs;
using BeHealthBackend.Services;
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
    public async Task<IEnumerable<DoctorDto>> GetAllDoctors()
    {
        var doctors = _doctorService.GetAll();

        return await doctors;
    }

    [HttpGet("{id}")]
    public async Task<DoctorDto> GetDoctorById([FromRoute] int id)
    {
        var doctor = _doctorService.GetById(id);

        return await doctor;
    }

    [HttpPost]
    public async Task<Doctor> AddDoctorAsync([FromBody] CreateDoctorDto dto)
    {
        if (!ModelState.IsValid) BadRequest(ModelState);
        return await _doctorService.Create(dto);
    }
}

