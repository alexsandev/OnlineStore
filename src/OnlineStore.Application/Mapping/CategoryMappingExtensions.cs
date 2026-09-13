using OnlineStore.Application.DTOs;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Mapping
{
    public static class CategoryMappingExtensions
    {
        public static CategoryDto ToCategoryDto(this Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                ImageUrl = category.ImageUrl
            };
        }
    }
}
