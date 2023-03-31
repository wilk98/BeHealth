using BeHealthBackend.DataAccess.DbContexts;
using BeHealthBackend.DataAccess.Entities;
using BeHealthBackend.DataAccess.Repositories.Interfaces;

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
