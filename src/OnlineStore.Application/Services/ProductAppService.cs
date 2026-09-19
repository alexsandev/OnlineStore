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
        private readonly IRepository<Product> _repository;

        public ProductAppService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<ProductDto> RegisterProductAsync(ProductDto productDto, CancellationToken ct)
        {
            var product = productDto.ToProduct();
            await _repository.AddAsync(product, ct);
            return product.ToProductDto();
        }

        public async Task<ProductPageDTO> GetProductPageAsync(int pageNumber, int pageSize, CancellationToken ct)
        {
            var pageRequest = new PageRequest(pageNumber, pageSize);

            var pageResult = await _repository.GetPageAsync(pageRequest, ct);

            return new ProductPageDTO()
            {
                TotalItems = (int)pageResult.TotalItems,
                TotalPages = pageResult.TotalPages,
                HasNextPage = pageResult.HasNextPage,
                HasPreviousPage = pageResult.HasPreviousPage,
                Items = pageResult.Items.Select(p => p.ToProductDto()).ToList()
            };
        }
    }
}
