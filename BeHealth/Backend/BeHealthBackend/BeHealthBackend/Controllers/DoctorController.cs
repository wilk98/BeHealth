using AutoMapper;
using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using BeHealthBackend.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BeHealthBackend.Controllers;

[ApiController, Route("/api/doctors")]
public class DoctorController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DoctorController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var doctors = await _unitOfWork.DoctorRepository
            .GetAllAsync(includeProperties: "Address");

        var doctorsDtos = _mapper.Map<List<DoctorDto>>(doctors);

        return Ok(doctorsDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDoctor([FromRoute] int id)
    {
        var doctor = await _unitOfWork.DoctorRepository
            .GetAsync(d=>d.Id == id, includeProperties: "Address");

        if (doctor is null) return NotFound();

        var doctorDto = _mapper.Map<DoctorDto>(doctor);

        return Ok(doctorDto);
    }

    [HttpPost]
    public async Task<IActionResult> AddDoctorAsync([FromBody] CreateDoctorDto dto)
    {
        if (!ModelState.IsValid) BadRequest(ModelState);
        var doctor = _mapper.Map<Doctor>(dto);
        await _unitOfWork.DoctorRepository.AddAsync(doctor);
        await _unitOfWork.SaveAsync();

        return Created($"/api/doctors/{doctor.Id}", null);
    }
}

