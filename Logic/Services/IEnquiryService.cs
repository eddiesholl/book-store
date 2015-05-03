using CarSales.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSales.Logic.Services
{
	public interface IEnquiryService : IService
	{
		void RecordEnquiry(string name, string email, Int64 carID);
		IEnumerable<EnquiryListModel> GetAllEnquiries();
	}
}
