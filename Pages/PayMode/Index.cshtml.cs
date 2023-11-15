using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;
using System.Collections;

namespace SupermarketWEB.Pages.PayMode
{
    public class IndexModel : PageModel
    {

            private readonly SupermarketContext _context;

            public IndexModel(SupermarketContext context)
            {
                _context = context;
            }

            public List<PayModes> PayMod { get; set; }

            public async Task OnGetAsync()
            {
                if (_context.PayMod != null)
                {
                PayMod = await _context.PayMod.ToListAsync();
                }
            }
    }
}

