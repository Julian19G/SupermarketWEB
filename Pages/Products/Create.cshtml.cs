using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly SupermarketContext _context;

        public CreateModel(SupermarketContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Products == null || Product == null)
            {
                return Page();
            }
            try
            {



                _context.Products.Add(Product);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al intentar guardar el producto. Por favor, int�ntalo de nuevo.");
                return Page();
            }
        }
    }
}
