using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using CarSales.Data.Domain;

namespace CarSales.Data.Models
{
	public class CarViewModel
	{
		[HiddenInput(DisplayValue=false)]
		public Int64 CarID { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public decimal? PriceAmount { get; set; }
		public PriceType PriceType { get; set; }
		public string Email { get; set; }
		//public ContactDetails ContactDetails { get; private set; }
		public string Comments { get; set; }

		[Required(ErrorMessage="Please include your name.",AllowEmptyStrings=false)]
		[DisplayName("Name")]
		public string EnquireName { get; set; }
		[Required(ErrorMessage = "Please include a valid email address.")]
		[DisplayName("Email address")]
		public string EnquireEmail { get; set; }
	}
}
