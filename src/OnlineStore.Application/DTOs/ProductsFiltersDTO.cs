namespace OnlineStore.Application.DTOs
{
    public record ProductsFiltersDTO(
        long? Category = null,
        int PageNumber = 1,
        int PageSize = 12,
        string? Search = null,
        decimal? MinPrice = null,
        decimal? MaxPrice = null,
        string? Order = null);
}
