﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CarSales.Data.Models
{
	public class CarViewModel
	{
		[HiddenInput(DisplayValue=false)]
		public int CarID { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public decimal Price { get; set; }
		public string Email { get; private set; }
		//public ContactDetails ContactDetails { get; private set; }
		public string Comments { get; private set; }
	}
}
