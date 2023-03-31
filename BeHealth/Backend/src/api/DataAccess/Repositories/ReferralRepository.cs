using BeHealthBackend.DataAccess.DbContexts;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using core;

namespace BeHealthBackend.DataAccess.Repositories;

public class ReferralRepository : Repository<Referral>, IReferralRepository
{
    public ReferralRepository(BeHealthContext context) : base(context)
    {
        DbSet = context.Referrals;
    }
}

