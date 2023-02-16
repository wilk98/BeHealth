using BeHealthBackend.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BeHealthBackend.DataAccess.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected DbSet<T> DbSet;

        protected Repository(DbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null)
        {
            IQueryable<T> query = DbSet;

            if (filter is not null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                query = includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Aggregate(query, (current, includeProperty) =>
                        current.Include(includeProperty));
            }

            if (orderBy is not null)
            {
                query = orderBy(query);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<T?> GetAsync(
            Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null)
        {
            IQueryable<T> query = DbSet;

            if (filter is not null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                query = includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Aggregate(query, (current, includeProperty) =>
                        current.Include(includeProperty));
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await DbSet.AddRangeAsync(entities);
        }

        public void Modify(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public void SetModified(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
