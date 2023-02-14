using BeHealthBackend.DataAccess.DbContexts;
using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using BeHealthBackend.DTOs.VisitDtoFolder;
using Microsoft.EntityFrameworkCore;

namespace BeHealthBackend.DataAccess.Repositories;

public class VisitRepository : Repository<Visit>, IVisitRepository
{
    public VisitRepository(BeHealthContext context) : base(context)
    {
        DbSet = context.Visits;
    }

    public async Task<IReadOnlyList<VisitCalendarDto>> GetVisitsForMonth(int doctorId, DateOnly date)
    {

        var visitDates = await DbSet
            .Where(visit => visit.DoctorId == doctorId)
            .Where(visit => visit.VisitDate.Month == date.Month && visit.VisitDate.Year == date.Year)
            .Select(visit => visit.VisitDate)
            .ToListAsync();

        var visitCalendarDto = visitDates
            .GroupBy(visit => visit.Day)
            .Select(group => new VisitCalendarDto
            {
                Day = group.Key,
                Visits = group.Count()
            })
            .ToList();

        return visitCalendarDto;
    }
}
