using OnlineStore.Application.DTOs;
using OnlineStore.Application.Interfaces;
using OnlineStore.Application.Mapping;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Interfaces;

namespace OnlineStore.Application.Services
{
    internal class ProductAppService : IProductAppService
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
    }
}
