using CarSales.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSales.Data.Models
{
	public class CarListModel
	{
		public Int64 CarID { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public Price Price { get; set; }
		public string Email { get; set; }
		//public ContactDetails ContactDetails { get; private set; }
		public string Comments { get; set; }
	}
}
