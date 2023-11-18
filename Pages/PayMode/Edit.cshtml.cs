using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.PayMode
{
    public class EditModel : PageModel
    {
        private readonly SupermarketContext _context;
        public EditModel(SupermarketContext context)
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
            var paymodes = await _context.PayMod.FirstOrDefaultAsync(m => m.Id == id);
            if (paymodes == null)
            {
                return NotFound();
            }
            PayModes = paymodes;
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PayModes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayModesExists(PayModes.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
        private bool PayModesExists(int id)
        {
            return (_context.PayMod?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
