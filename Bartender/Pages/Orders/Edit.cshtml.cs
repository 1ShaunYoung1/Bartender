using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bartender.Models;

namespace Bartender.Pages.Orders
{
    public class EditModel : PageModel
    {
        private readonly Bartender.Models.BartenderContext _context;

        public EditModel(Bartender.Models.BartenderContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(OrderUp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderUpExists(OrderUp.Id))
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

        private bool OrderUpExists(int id)
        {
            return _context.OrderUp.Any(e => e.Id == id);
        }
    }
}
