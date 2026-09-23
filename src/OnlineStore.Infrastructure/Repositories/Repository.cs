using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Interfaces;
using OnlineStore.Domain.Pagination;
using OnlineStore.Infrastructure.Context;

namespace OnlineStore.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OnlineStoreDbContext _context;

        public Repository(OnlineStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity, CancellationToken ct = default)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(long id, CancellationToken ct = default)
        {
            T? entity = await _context.Set<T>().FindAsync(id, ct);
            if(entity is not null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync(ct);
            }
        }

        public async Task<T?> GetAsync(long id, CancellationToken ct = default)
        {
            return await _context.Set<T>().FindAsync(id, ct);
        }

        public async Task<PageResult<T>> GetPageAsync(PageRequest pr, CancellationToken ct = default)
        {
            var pageNumber = pr.PageNumber;
            var pageSize = pr.PageSize;
            var totalItems = _context.Set<T>().Count();
            var items = await _context.Set<T>().Skip((pr.PageNumber - 1) * pr.PageSize).Take(pr.PageSize).AsNoTracking().ToListAsync(ct);
            return new PageResult<T>(items, totalItems, pageNumber, pageSize);
        }

        public async Task UpdateAsync(T entity, CancellationToken ct = default)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync(ct);
        }
    }
}
