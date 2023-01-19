using BeHealthBackend.DataAccess.DbContexts;
using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using CityInfo.API.DataAccess.Repositories;

namespace BeHealthBackend.DataAccess.Repositories;

public class AddressRepository : Repository<Address>, IAddressRepository
{
    public AddressRepository(BeHealthContext context) : base(context)
    {
    }
}
