using OnlineStore.Domain.Pagination;

namespace OnlineStore.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetAsync(long id, CancellationToken ct = default);
        Task<PageResult<T>> GetPageAsync(PageRequest pr, CancellationToken ct = default);
        Task AddAsync(T entity, CancellationToken ct = default);
        Task UpdateAsync(T entity, CancellationToken ct = default);
        Task DeleteAsync(long id, CancellationToken ct = default);
    }
}
