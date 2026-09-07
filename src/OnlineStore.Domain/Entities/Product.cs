namespace OnlineStore.Domain.Entities
{
    public class Product : Entity
    {
        public required string Name { get; set; }
        public string ShortDescription { get; set; } = "No content";
        public string Description { get; set; } = "No content";
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? MainImageUrl { get; set; }
        public ISet<string> ImagesUrl { get; set; } = new HashSet<string>();
    }
}
