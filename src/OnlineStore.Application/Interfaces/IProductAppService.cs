using OnlineStore.Application.DTOs;

namespace OnlineStore.Application.Interfaces
{
    public interface IProductAppService
    {
        Task<ProductDto> RegisterProductAsync(ProductDto createProductDto, CancellationToken ct);
        Task<ProductPageDTO> GetProductPageAsync(int pageNumber, int pageSize, CancellationToken ct);
        Task<ProductDto?> GetProductByIdAsync(long id, CancellationToken ct);
    }
}
