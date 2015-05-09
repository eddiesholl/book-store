using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSales.Data.Domain
{
	public enum ListingType
	{
		Private,
		Dealer
	}

	public class Book
	{
		public Int64 BookID { get; private set; }
		public string Author { get; private set; }
		public string Title { get; private set; }
		public int Year { get; private set; }
		public Price Price { get; private set; }
		public string Email { get; private set; }
		public ListingType ListingType { get; private set; }
		public string ABN { get; private set; }
		public string ContactName { get; private set; }
		public string Phone { get; private set; }
		public string Comments { get; private set; }


		public Book(
			int bookID,
			string author, string title,
			int year, Price price, string email,
			ListingType listingType, string abn, string contactName, string phone,
			string comments = "")
		{
			this.BookID = bookID;
			this.Author = author;
			this.Title = title;
			this.Year = year;
			this.Price = price;
			this.Email = email;
			this.ListingType = listingType;
			this.ABN = abn;
			this.ContactName = contactName;
			this.Phone = phone;
			this.Comments = comments;
		}

		public void MakePrivateListing()
		{
			this.ListingType = Domain.ListingType.Private;
			this.ABN = null;
		}

		public void MakeDealerListing()
		{
			this.ListingType = Domain.ListingType.Dealer;
			this.ContactName = null;
			this.Phone = null;
		}
	}
}
