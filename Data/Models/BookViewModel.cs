using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using BookSales.Data.Domain;

namespace BookSales.Data.Models
{
	public class BookViewModel
	{
		[HiddenInput(DisplayValue=false)]
		public Int64 BookID { get; set; }
		public string Author { get; set; }
		public string Title { get; set; }
		public int Year { get; set; }
		public decimal? PriceAmount { get; set; }
		public PriceType PriceType { get; set; }
		public string Email { get; set; }

		public ListingType ListingType { get; set; }
		public string ContactName { get; set; }
		public string Phone { get; set; }
		public string ABN { get; set; }

		public string Comments { get; set; }

		[Required(ErrorMessage="Please include your name.", AllowEmptyStrings=false)]
		[DisplayName("Name")]
		public string EnquireName { get; set; }
		[Required(ErrorMessage = "Please include a valid email address.")]
		[DisplayName("Email address")]
		public string EnquireEmail { get; set; }
	}
}
