using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSales.Data.Domain
{
	/// <summary>
	/// Simple storage of enquiries from users
	/// </summary>
	public class Enquiry
	{
		public string Name { get; private set; }
		public string Email { get; private set; }
		public Int64 CarID { get; private set; }

		public Enquiry(string name, string email, Int64 carID)
		{
			this.Name = name;
			this.Email = email;
			this.CarID = carID;
		}
	}
}
