using BeHealthBackend.DataAccess.DbContexts;
using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using CityInfo.API.DataAccess.Repositories;

namespace BeHealthBackend.DataAccess.Repositories;

public class VisitRepository : Repository<Visit>, IVisitRepository
{
    public VisitRepository(BeHealthContext context) : base(context)
    {
    }
}
