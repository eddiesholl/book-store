using BookSales.Data.Domain;
using BookSales.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSales.Logic.Services
{
	public class EnquiryService : IEnquiryService
	{
		// Obviously not thread safe, just demo persistence
		static List<Enquiry> _enquiries = new List<Enquiry>();

		public void RecordEnquiry(string name, string email, Int64 bookID)
		{
			_enquiries.Add(new Enquiry(name, email, bookID));
		}

		public IEnumerable<EnquiryListModel> GetAllEnquiries()
		{
			return _enquiries.Select(e => new EnquiryListModel { BookID = e.BookID, Email = e.Email, Name = e.Name });
		}
	}
}
