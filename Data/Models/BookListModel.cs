using BookSales.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSales.Data.Models
{
	public class BookListModel
	{
		public Int64 BookID { get; set; }
		public string Author { get; set; }
		public string Title { get; set; }
		public int Year { get; set; }
		public Price Price { get; set; }
		public string Email { get; set; }
		public string Comments { get; set; }
	}
}
