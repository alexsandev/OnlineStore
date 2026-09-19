using OnlineStore.Domain.Exceptions;

namespace OnlineStore.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string? MainImageUrl { get; private set; }
        private readonly List<string> _imagesUrl = new();
        public IReadOnlyCollection<string> ImagesUrl => _imagesUrl.AsReadOnly();
        private readonly List<ProductCategory> _productCategories = new();
        public IReadOnlyCollection<ProductCategory> ProductCategories => _productCategories.AsReadOnly();

        protected Product()
        {
            Name = null!;
            ShortDescription = null!;
            Description = null!;
        }

        public Product(string name, string shortDescription = "", string description = "", string? mainImageUrl = null, decimal price = 0, int stock = 0)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new DomainException("Product name cannot be null or empty.");

            if(price < 0)
                throw new DomainException("Product price cannot be negative.");

            if (stock < 0)
                throw new DomainException("Product stock cannot be negative.");

            Name = name;
            ShortDescription = shortDescription;
            Description = description;
            MainImageUrl = mainImageUrl;
            Price = price;
            Stock = stock;
        }
    }
}
