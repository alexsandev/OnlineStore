namespace OnlineStore.Application.DTOs
{
    public record CategoryDto
    {
        public long? Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
