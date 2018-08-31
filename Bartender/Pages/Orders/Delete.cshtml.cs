using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bartender.Models;

namespace Bartender.Pages.Orders
{
    public class DeleteModel : PageModel
    {
        private readonly Bartender.Models.BartenderContext _context;

        public DeleteModel(Bartender.Models.BartenderContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OrderUp OrderUp { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderUp = await _context.OrderUp.FirstOrDefaultAsync(m => m.Id == id);

            if (OrderUp == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderUp = await _context.OrderUp.FindAsync(id);

            if (OrderUp != null)
            {
                _context.OrderUp.Remove(OrderUp);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
