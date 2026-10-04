using OnlineStore.Application.DTOs;

namespace OnlineStore.Application.Interfaces
{
    public interface IProductAppService
    {
        Task<ProductDto> RegisterProductAsync(ProductDto createProductDto, CancellationToken ct);
        Task<ProductsPageDTO> GetProductPageAsync(ProductsFiltersDTO filters, CancellationToken ct);
        Task<ProductDto?> GetProductByIdAsync(long id, CancellationToken ct);
    }
}
