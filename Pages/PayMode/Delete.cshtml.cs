using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.PayMode
{
    public class DeleteModel : PageModel
    {
        private readonly SupermarketContext _context;

        public DeleteModel(SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PayModes PayModes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PayMod == null)
            {
                return NotFound();
            }

            var paymodes = await _context.PayMod.FirstOrDefaultAsync(x => x.Id == id);

            if (paymodes == null)
            {
                return NotFound();
            }
            else
            {
                PayModes = paymodes;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PayMod == null)
            {
                return NotFound();
            }
            var paymodes = await _context.PayMod.FindAsync(id);
            if (paymodes != null)
            {
                PayModes = paymodes;
                _context.PayMod.Remove(PayModes);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
