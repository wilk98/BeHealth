using AutoMapper;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using BeHealthBackend.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BeHealthBackend.Controllers;

[ApiController, Route("/api/patients")]
public class PatientController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PatientController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var patients = await _unitOfWork.PatientRepository
            .GetAllAsync();

        var patientsDtos = _mapper.Map<List<PatientDto>>(patients);

        return Ok(patientsDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDoctor([FromRoute] int id)
    {
        var patient = await _unitOfWork.PatientRepository
            .GetAsync(id);

        if (patient is null) return NotFound();

        var patientDto = _mapper.Map<PatientDto>(patient);

        return Ok(patientDto);
    }
}
