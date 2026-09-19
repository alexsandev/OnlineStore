namespace OnlineStore.Domain.Pagination
{
    public record PageRequest(int PageNumber = 1, int PageSize = 10)
    {
        public int PageNumber { get; init; } = PageNumber < 1 ? 1 : PageNumber;
        public int PageSize { get; init; } = PageSize switch
        {
            < 1 => 10,
            > 100 => 100,
            _ => PageSize
        };
    }
}
