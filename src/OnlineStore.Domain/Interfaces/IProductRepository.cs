using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<PageResult<Product>> GetProductsPageWithFiltersAsync(ProductsPageRequest pageRequest, CancellationToken ct);
    }
}
