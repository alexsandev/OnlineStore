using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineStore.Application.DTOs;
using OnlineStore.Application.Interfaces;

namespace OnlineStore.Webapp.Pages.Products
{
    public class IndexModel : PageModel
    {

        private readonly IProductAppService _service;

        public ProductPageDTO ProductPage { get; set; } = null!;

        public IndexModel(IProductAppService service)
        {
            _service = service;
        }

        public async Task OnGet(CancellationToken ct, [FromQuery]int page = 1,[FromQuery]int size = 12)
        {
            var productPage = await _service.GetProductPageAsync(page, size, ct);

            ProductPage = productPage;
        }
    }
}
