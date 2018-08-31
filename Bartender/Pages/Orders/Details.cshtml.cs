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
    public class DetailsModel : PageModel
    {
        private readonly Bartender.Models.BartenderContext _context;

        public DetailsModel(Bartender.Models.BartenderContext context)
        {
            _context = context;
        }

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
    }
}
