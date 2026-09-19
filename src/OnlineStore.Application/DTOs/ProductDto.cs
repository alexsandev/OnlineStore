namespace OnlineStore.Application.DTOs
{
    public record ProductDto
    {
        public long? Id { get; set; }
        public required string Name { get; set; }
        public string ShortDescription { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? MainImageUrl { get; set; }
        public ICollection<string> ImagesUrls = new List<string>();
        public ICollection<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    }
}
