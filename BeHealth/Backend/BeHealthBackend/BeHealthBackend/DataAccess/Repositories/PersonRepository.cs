using BeHealthBackend.DataAccess.DbContexts;
using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using CityInfo.API.DataAccess.Repositories;

namespace BeHealthBackend.DataAccess.Repositories;

public class PersonRepository : Repository<Person>, IPersonRepository
{
    public PersonRepository(BeHealthContext context) : base(context)
    {
    }
}
