using OnlineStore.Application.DTOs;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Mapping
{
    public static class ProductMappingExtensions
    {
        public static ProductDto ToProductDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                ShortDescription = product.ShortDescription,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                MainImageUrl = product.MainImageUrl,
                ImagesUrls = product.ImagesUrl.ToList(),
                Categories = product.ProductCategories.Select(x => x.Category!.ToCategoryDto()).ToList()
            };
        }

        public static Product ToProduct(this ProductDto productDto)
        {
            var product = new Product(
                productDto.Name,
                productDto.ShortDescription,
                productDto.Description,
                productDto.MainImageUrl,
                productDto.Price,
                productDto.Stock
            );

            return product;
        }
    }
}
