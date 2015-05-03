using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSales.Data.Domain
{

	public class Car
	{
		public Int64 CarID { get; private set; }
		public string Make { get; private set; }
		public string Model { get; private set; }
		public int Year { get; private set; }
		public Price Price { get; private set; }
		public string Email { get; private set; }
		public ContactDetails ContactDetails { get; private set; }
		public string Comments { get; private set; }


		public Car(int carID, string make, string model, int year, Price price, string email, ContactDetails contactDetails, string comments = "")
		{
			this.CarID = carID;
			this.Make = make;
			this.Model = model;
			this.Year = year;
			this.Price = price;
			this.Email = email;
			this.ContactDetails = contactDetails;
			this.Comments = comments;
		}
	}
}
