using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bartender.Models
{
	public class OrderUp
	{
		public int Id { get; set; }
		public string Patron { get; set; }
		public string DrinkType { get; set; }
	}
}
