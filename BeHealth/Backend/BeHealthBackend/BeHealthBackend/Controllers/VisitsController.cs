using BeHealthBackend.DataAccess.Repositories.Interfaces;
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
        var visits = await _unitOfWork.VisitRepository.GetAllAsync();
        return Ok(visits);
    }
}
