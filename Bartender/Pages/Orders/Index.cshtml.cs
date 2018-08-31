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
    public class IndexModel : PageModel
    {
        private readonly Bartender.Models.BartenderContext _context;

        public IndexModel(Bartender.Models.BartenderContext context)
        {
            _context = context;
        }

        public IList<OrderUp> OrderUp { get;set; }

        public async Task OnGetAsync()
        {
            OrderUp = await _context.OrderUp.ToListAsync();
        }
    }
}
