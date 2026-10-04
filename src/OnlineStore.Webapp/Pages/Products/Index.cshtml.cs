using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineStore.Application.DTOs;
using OnlineStore.Application.Interfaces;

namespace OnlineStore.Webapp.Pages.Products
{
    [BindProperties(SupportsGet = true)]
    public class IndexModel : PageModel
    {
        private readonly IProductAppService _service;

        public IndexModel(IProductAppService service)
        {
            _service = service;
        }

        [FromRoute]
        public string? Category { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 12;
        public string? Search { get; set; }
        public string? Order { get; set; } = "relevancia";
        public decimal? MaxPrice { get; set; }
        public decimal? MinPrice { get; set; }

        [BindNever]
        public ProductsPageDTO ProductsPage { get; set; } = new();
        
        public async Task<IActionResult> OnGet(CancellationToken ct)
        {
            if (!IsValidPageNumber()) PageNumber = 1;

            if (!IsValidPageSize()) PageSize = 12;

            ProductsPage = await _service.GetProductPageAsync(CreateProductsFilterDTO(), ct);
                
            return Page();
        }

        private bool IsValidPageNumber() => PageNumber > 0;

        private bool IsValidPageSize() => PageSize == 12 || PageSize == 24 || PageSize == 36;

        private ProductsFiltersDTO CreateProductsFilterDTO() => new ProductsFiltersDTO(null, PageNumber, PageSize, Search, MinPrice, MaxPrice, Order);
        
    }
}
