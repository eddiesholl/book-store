using CarSales.Data.Domain;
using CarSales.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSales.Logic.Services
{
	public class EnquiryService : IEnquiryService
	{
		// Obviously not thread safe, just demo persistence
		static List<Enquiry> _enquiries = new List<Enquiry>();

		public void RecordEnquiry(string name, string email, Int64 carID)
		{
			_enquiries.Add(new Enquiry(name, email, carID));
		}

		public IEnumerable<EnquiryListModel> GetAllEnquiries()
		{
			return _enquiries.Select(e => new EnquiryListModel { CarID = e.CarID, Email = e.Email, Name = e.Name });
		}
	}
}
