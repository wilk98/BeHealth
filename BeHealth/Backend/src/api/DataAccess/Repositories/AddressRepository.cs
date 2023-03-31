using BeHealthBackend.DataAccess.DbContexts;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using core;

namespace BeHealthBackend.DataAccess.Repositories;

public class AddressRepository : Repository<Address>, IAddressRepository
{
    public AddressRepository(BeHealthContext context) : base(context)
    {
        DbSet = context.Addresses;
    }
}
