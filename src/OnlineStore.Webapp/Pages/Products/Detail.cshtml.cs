using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineStore.Application.DTOs;
using OnlineStore.Application.Interfaces;

namespace OnlineStore.Webapp.Pages.Products
{
    public class DetailModel : PageModel
    {
        private readonly IProductAppService _service;

        public ProductDto Product { get; set; } = null!;

        public DetailModel(IProductAppService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnGetAsync(long id, CancellationToken ct)
        {
            var product = await _service.GetProductByIdAsync(id, ct);

            if(product is null)
                return NotFound();

            Product = product;
            return Page();
        }
    }
}
