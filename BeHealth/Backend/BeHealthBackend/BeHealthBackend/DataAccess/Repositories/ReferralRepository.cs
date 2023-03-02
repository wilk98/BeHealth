using BeHealthBackend.DataAccess.DbContexts;
using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DataAccess.Repositories.Interfaces;

namespace BeHealthBackend.DataAccess.Repositories;

public class ReferralRepository : Repository<Referral>, IReferralRepository
{
    public ReferralRepository(BeHealthContext context) : base(context)
    {
        DbSet = context.Referrals;
    }
}

