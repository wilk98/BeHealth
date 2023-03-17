using BeHealthBackend.DTOs.ReferralDtoFolder;
using BeHealthBackend.Services.ReferralService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeHealthBackend.Controllers;

[ApiController, Route("/api/referrals")]
//[Authorize(Roles = "Patient")]
public class ReferralController : ControllerBase
{
    private readonly IReferralService _referralService;

    public ReferralController(IReferralService referralService)
    {
        _referralService = referralService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<ReferralDto>>> GetReferralsByIdAsync([FromRoute] int id)
    {
        var referrals = await _referralService.GetIdAsync(id);
        return Ok(referrals);
    }

}

