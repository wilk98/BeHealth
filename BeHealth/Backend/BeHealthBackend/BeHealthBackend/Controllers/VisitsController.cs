using BeHealthBackend.DTOs.Visit;
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
    public async Task<IEnumerable<VisitDTO>> GetAllVisitsForDoctor(int doctorId)
    {
        var visits = _visitsService.GetVisitsByDoctorIdAsync(doctorId);
        return await visits;
    }

    [HttpPost]
    public async Task<int?> AddVisit([FromBody] CreateVisitDto visitDto)
    {
        var visit = await _visitsService.AddVisit(visitDto);
        return visit?.Id;
    }
    [HttpPut("{id}")]
    public async Task<bool> PutVisit([FromRoute]int id, [FromBody]PutVisitDto visitDto)
    {
        var visit = await _visitsService.PutVisit(id, visitDto);
        return visit != null;
    }
    [HttpDelete("{id}")]
    public async Task DeleteVisit([FromRoute]int id)
    {
        await _visitsService.DeleteVisit(id);
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
