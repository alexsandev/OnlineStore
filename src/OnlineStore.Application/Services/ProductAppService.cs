using OnlineStore.Application.DTOs;
using OnlineStore.Application.Interfaces;
using OnlineStore.Application.Mapping;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Interfaces;
using OnlineStore.Domain.Pagination;

namespace OnlineStore.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _repository;

        public ProductAppService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductDto> RegisterProductAsync(ProductDto productDto, CancellationToken ct)
        {
            var product = productDto.ToProduct();
            await _repository.AddAsync(product, ct);
            return product.ToProductDto();
        }

        public async Task<ProductsPageDTO> GetProductPageAsync(ProductsFiltersDTO filters, CancellationToken ct)
        {
            var pageRequest = filters.ToPageRequest();

            var pageResult = await _repository.GetProductsPageWithFiltersAsync(pageRequest, ct);

            return new ProductsPageDTO()
            {
                CurrentPage = pageResult.PageNumber,
                CurrentSize = pageResult.PageSize,
                TotalItems = (int)pageResult.TotalItems,
                TotalPages = pageResult.TotalPages,
                HasNextPage = pageResult.HasNextPage,
                HasPreviousPage = pageResult.HasPreviousPage,
                Items = pageResult.Items.Select(p => p.ToProductDto()).ToList()
            };
        }

        public async Task<ProductDto?> GetProductByIdAsync(long id, CancellationToken ct)
        {
            var product = await _repository.GetByIdAsync(id, ct);
            return product?.ToProductDto();
        }
    }
}
