using BeHealthBackend.DataAccess.DbContexts;
using BeHealthBackend.DataAccess.Repositories.Interfaces;
using core;

namespace BeHealthBackend.DataAccess.Repositories
{
    public class WorkHoursRepository : Repository<WorkHours>, IWorkHoursRepository
    {
        public WorkHoursRepository(BeHealthContext context) : base(context)
        {
            DbSet = context.WorkHours;
        }
    }
}
