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
        return await _doctorService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<DoctorDto> GetDoctorById([FromRoute] int id)
    {
        return await _doctorService.GetById(id);
    }

    [HttpPost]
    public async Task<Doctor> AddDoctorAsync([FromBody] CreateDoctorDto dto)
    {
        if (!ModelState.IsValid) BadRequest(ModelState);
        return await _doctorService.Create(dto);
    }

    [HttpPut("{id}")]
    public async Task<Doctor?> UpdateDoctor([FromRoute] int id, [FromBody] UpdateDoctorDto dto)
    {
        if (!ModelState.IsValid) BadRequest(ModelState);
        return await _doctorService.Update(id, dto);
    }


    [HttpDelete("{id}")]
    public async Task<Doctor?> DeleteDoctorById([FromRoute] int id)
    {
        return await _doctorService.Delete(id);
    }
}

