using OnlineStore.Domain.Exceptions;

namespace OnlineStore.Domain.Entities;

public class Category : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string ImageUrl { get; private set; }
    public long? ParentCategoryId { get; private set; }
    public Category? ParentCategory { get; private set; }
    private readonly List<Category> _subcategories = new();
    public IReadOnlyCollection<Category> Subcategories => _subcategories.AsReadOnly();
    private readonly List<ProductCategory> _productCategories = new();
    public IReadOnlyCollection<ProductCategory> ProductCategories => _productCategories.AsReadOnly();

    protected Category() 
    {
        Name = null!;
        Description = null!;
        ImageUrl = null!;
    }

    public Category(string name, string description = "", string imageUrl = "")
    {
        if(string.IsNullOrWhiteSpace(name))
            throw new DomainException("Category name cannot be null or empty.");

        Name = name;
        Description = description;
        ImageUrl = imageUrl;
    }

    public void AddSubcategory(Category subcategory) => throw new NotImplementedException();
    public void SetParentCategory(Category parentCategory) => throw new NotImplementedException();
    public bool IsAncestral(Category candidate)
    {
        if (candidate is null)
            return false;

        var current = ParentCategory;

        while (current is not null)
        {
            if(candidate.Id > 0 && current.Id == candidate.Id || current == candidate)
                return true;

            current = current.ParentCategory;
        }
        return false;
    }
    public bool IsRoot() => ParentCategoryId is null;
    public bool IsLeaf() => !_subcategories.Any();
}
