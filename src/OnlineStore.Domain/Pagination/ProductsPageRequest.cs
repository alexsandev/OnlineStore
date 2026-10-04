namespace OnlineStore.Domain.Pagination
{
    public record ProductsPageRequest : PageRequest
    {
        public string? Name { get; init; }
        public long? CategoryId { get; init; }
        public decimal? MinPrice { get; init; }
        public decimal? MaxPrice { get; init; }
        public string? Order { get; init; }
    }
}
