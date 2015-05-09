using BookSales.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSales.Logic.Services
{
	public interface IEnquiryService : IService
	{
		void RecordEnquiry(string name, string email, Int64 bookID);
		IEnumerable<EnquiryListModel> GetAllEnquiries();
	}
}
