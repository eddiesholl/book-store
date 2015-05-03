using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSales.Data.Domain
{
	public enum ListingType
	{
		Private,
		Dealer
	}

	public class Car
	{
		public Int64 CarID { get; private set; }
		public string Make { get; private set; }
		public string Model { get; private set; }
		public int Year { get; private set; }
		public Price Price { get; private set; }
		public string Email { get; private set; }
		public ListingType ListingType { get; private set; }
		public string ABN { get; private set; }
		public string ContactName { get; private set; }
		public string Phone { get; private set; }
		public string Comments { get; private set; }


		public Car(
			int carID,
			string make, string model,
			int year, Price price, string email,
			ListingType listingType, string abn, string contactName, string phone,
			string comments = "")
		{
			this.CarID = carID;
			this.Make = make;
			this.Model = model;
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
