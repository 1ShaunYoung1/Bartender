using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bartender.Models;

namespace Bartender.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly Bartender.Models.BartenderContext _context;

        public CreateModel(Bartender.Models.BartenderContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public OrderUp OrderUp { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.OrderUp.Add(OrderUp);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}