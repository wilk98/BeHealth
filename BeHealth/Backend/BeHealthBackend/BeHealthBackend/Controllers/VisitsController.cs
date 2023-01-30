using BeHealthBackend.DataAccess.Repositories.Interfaces;
using BeHealthBackend.DTOs;
using BeHealthBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeHealthBackend.Controllers;

[ApiController, Route("/api/visits")]
public class VisitsController : ControllerBase
{
    private readonly IVisitsService _visitsService;

    public VisitsController(IVisitsService visitsService)
    {
        _visitsService = visitsService;
    }

    [HttpGet("{doctorId}")]
    public async Task<IEnumerable<VisitDTO>> GetAllVisitsForDoctor(Guid doctorId)
    {
        var visits = _visitsService.GetVisitsByDoctorIdAsync(doctorId);
        return await visits;
    }
    [HttpPost("{visitId}/decline")]
    public async Task<bool> DeclineVisit(int visitId)
    {
        return await _visitsService.DeclineVisit(visitId);
    }


    [HttpPost("{visitId}/accept")]
    public async Task<bool> AcceptVisit(int visitId)
    {
        return await _visitsService.AcceptVisit(visitId);
    }
}
