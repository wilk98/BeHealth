using BeHealthBackend.DataAccess.Repositories.Interfaces;
using BeHealthBackend.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BeHealthBackend.Controllers;

[ApiController, Route("/api/visits")]
public class VisitsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public VisitsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var visits = await _unitOfWork.VisitRepository
            .GetAllAsync(includeProperties: "Patient");

        var visitsDTO = visits.Select(v => new VisitDTO
            {
                Duration = v.Duration,
                Patient = $"{v.Patient.FirstName} {v.Patient.LastName}",
                Treatment = v.Name,
                StartDate = new DateTimeOffset(v.VisitDate).ToUnixTimeSeconds(),
            });
        return Ok(visitsDTO);
    }
}
