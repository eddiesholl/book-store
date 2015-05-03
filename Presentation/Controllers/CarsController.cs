using CarSales.Data.Models;
using CarSales.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarSales.Presentation.Controllers
{
	public class CarsController : Controller
	{
		ICarService _carService;
		IEnquiryService _enquiryService;
		public CarsController(ICarService carService, IEnquiryService enquiryService)
		{
			_carService = carService;
			_enquiryService = enquiryService;
		}

		public ActionResult List()
		{
			var allCars = _carService.GetAllCars().ToList();

			return View(allCars);
		}

		[HttpGet]
		public ActionResult Detail(int carID)
		{
			var matchedCar = _carService.GetCar(carID);

			return View(matchedCar);
		}

		
		[HttpPost]
		public ActionResult Detail(CarViewModel postData)
		{
			if (ModelState.IsValid)
			{
				// Save the enquiry details to persistence etc
				_enquiryService.RecordEnquiry(postData.EnquireName, postData.EnquireEmail, postData.CarID);

				return RedirectToAction("Enquire", new { carID = postData.CarID });
			}
			else
			{
				return View(postData);
			}
		}

		public ActionResult Enquire(int carID)
		{
			var matchedCar = _carService.GetCar(carID);

			return View(matchedCar);
		}
	}
}