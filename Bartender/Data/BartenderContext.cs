using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bartender.Models
{
    public class BartenderContext : DbContext
    {
        public BartenderContext (DbContextOptions<BartenderContext> options)
            : base(options)
        {
        }

        public DbSet<Bartender.Models.OrderUp> OrderUp { get; set; }
    }
}
