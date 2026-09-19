using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineStore.Application.DTOs;
using OnlineStore.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Webapp.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IProductAppService _productAppService;
        [BindProperty]
        public InputModel Input { get; set; } = new();

        public record InputModel
        {
            [Required(ErrorMessage = "O nome é obrigatório.")]
            [StringLength(100, MinimumLength = 3, ErrorMessage = "Deve ter entre 3 e 100 caracteres.")]
            public string Name { get; set; } = string.Empty;
            public string ShortDescription { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "O valor não pode ser negativo.")]
            public decimal Price { get; set; }
            [Range(0, 9999, ErrorMessage = "A quantidade em estoque deve estar entre 0 e 9999")]
            public int Stock { get; set; }
            public string? MainImageUrl { get; set; }
        }

        public CreateModel(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public void OnGet()
        { 
        }

        public async Task<IActionResult> OnPost(CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                var ProductDto = new ProductDto
                {
                    Name = Input.Name,
                    ShortDescription = Input.ShortDescription,
                    Description = Input.Description,
                    Price = Input.Price,
                    Stock = Input.Stock,
                    MainImageUrl = Input.MainImageUrl
                };
                var product = await _productAppService.RegisterProductAsync(ProductDto, ct);
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
