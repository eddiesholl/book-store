using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSales.Data.Domain
{
	public abstract class ContactDetails
	{
	}

	public class PrivateContactDetails : ContactDetails
	{
		public string Name { get; private set; }
		public string PhoneNo { get; private set; }

		public PrivateContactDetails(string name, string phoneNo)
		{
			this.Name = name;
			this.PhoneNo = phoneNo;
		}
	}

	public class DealerContactDetails : ContactDetails
	{
		public int ABN { get; private set; }

		public DealerContactDetails(int abn)
		{
			this.ABN = abn;
		}
	}
}
