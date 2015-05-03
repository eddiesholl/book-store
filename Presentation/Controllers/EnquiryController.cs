using CarSales.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarSales.Presentation.Controllers
{
	public class EnquiryController : Controller
	{
		IEnquiryService _enquiryService;
		public EnquiryController(ICarService carService, IEnquiryService enquiryService)
		{
			_enquiryService = enquiryService;
		}

		public ActionResult List()
		{
			var allEnquiries = _enquiryService.GetAllEnquiries().ToList();

			return View(allEnquiries);
		}
	}
}