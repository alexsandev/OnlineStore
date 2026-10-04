using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Interfaces;
using OnlineStore.Domain.Pagination;
using OnlineStore.Infrastructure.Context;

namespace OnlineStore.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(OnlineStoreDbContext context) : base(context)
        {
        }

        public async Task<PageResult<Product>> GetProductsPageWithFiltersAsync(ProductsPageRequest pageRequest, CancellationToken ct)
        {
            var pageNumber = pageRequest.PageNumber;
            var pageSize = pageRequest.PageSize;
            var query = _context.Products.AsQueryable();

            if(!string.IsNullOrEmpty(pageRequest.Name))
                query = query.Where(p => p.Name.Contains(pageRequest.Name));

            if(pageRequest.CategoryId.HasValue)
                query = query.Where(p => p.ProductCategories.Any(pc => pc.CategoryId == pageRequest.CategoryId.Value));

            if(pageRequest.MinPrice.HasValue)
                query = query.Where(p => p.Price >= pageRequest.MinPrice.Value);

            if(pageRequest.MaxPrice.HasValue)
                query = query.Where(p => p.Price <= pageRequest.MaxPrice.Value);

            if(!string.IsNullOrEmpty(pageRequest.Order))
            {
                query = pageRequest.Order.ToLower() switch
                {
                    "price_asc" => query.OrderBy(p => p.Price),
                    "price_desc" => query.OrderByDescending(p => p.Price),
                    _ => query.OrderBy(p => p.UpdatedAt)
                };
            }
            
            var totalItems = query.Count();

            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            pageNumber = pageNumber > totalPages ? totalPages : pageNumber;

            var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync(ct);

            return new PageResult<Product>(items, totalItems, pageNumber, pageSize);
        }
    }
}
