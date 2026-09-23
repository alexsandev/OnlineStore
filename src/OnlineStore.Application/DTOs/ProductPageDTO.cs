using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Application.DTOs
{
    public record ProductPageDTO
    {
        public int CurrentSize { get; set; }
        public int CurrentPage { get; init; }
        public int TotalItems { get; init; }
        public int TotalPages { get; init; }
        public bool HasNextPage { get; init; }
        public bool HasPreviousPage { get; init; }
        public List<ProductDto> Items { get; init; } = new List<ProductDto>();
    }
}
