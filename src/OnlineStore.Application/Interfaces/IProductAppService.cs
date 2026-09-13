using OnlineStore.Application.DTOs;

namespace OnlineStore.Application.Interfaces
{
    public interface IProductAppService
    {
        Task<ProductDto> RegisterProductAsync(ProductDto createProductDto, CancellationToken ct);
    }
}
