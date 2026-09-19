namespace OnlineStore.Domain.Entities
{
    public class ProductCategory
    {
        public long ProductId { get; private set; }
        public Product? Product { get; private set; }
        public long CategoryId { get; private set; }
        public Category? Category { get; private set; }
        public bool IsMainCategory { get; private set; }

        protected ProductCategory() { }
        public ProductCategory(long productId, long categoryId, bool isMainCategory)
        {
            ProductId = productId;
            CategoryId = categoryId;
            IsMainCategory = isMainCategory;
        }
    }
}
