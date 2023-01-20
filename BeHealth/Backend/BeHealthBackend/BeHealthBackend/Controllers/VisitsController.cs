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
        // Za duże zapytanie
        /*
          info: Microsoft.EntityFrameworkCore.Database.Command[20101]
          Executed DbCommand (28ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
          SELECT [v].[Id], [v].[DoctorId], [v].[Duration], [v].[Name], [v].[PatientId], [v].[VisitDate], [p].[Id], [p].[AddressId], [p].[Created], [p].[Email], [p].[FirstName], [p].[LastName], [p].[Pesel], [p].[PhoneNumber], [d].[Id], [d].[AddressId], [d].[Created], [d].[Email], [d].[FirstName], [d].[LastName], [d].[PhoneNumber], [d].[Specialist]
          FROM [Visit] AS [v]
          INNER JOIN [Patient] AS [p] ON [v].[PatientId] = [p].[Id]
          INNER JOIN [Doctor] AS [d] ON [v].[DoctorId] = [d].[Id]
         */
        var visits = await _unitOfWork.VisitRepository
            .GetAllAsync(includeProperties: "Patient");

        var visitsDTO = visits.Select(v => new VisitDTO
            {
                Duration = v.Duration,
                Patient = $"{v.Patient.FirstName} {v.Patient.LastName}",
                Treatment = v.Name,
                StartDate = new DateTimeOffset(v.VisitDate).ToUnixTimeMilliseconds(),
            });
        return Ok(visitsDTO);
    }
}
