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
		public CarsController(ICarService carService)
		{
			_carService = carService;
		}

		public ActionResult List()
		{
			var allCars = _carService.GetAllCars().ToList();

			return View(allCars);
		}

		[HttpGet]
		public ActionResult Detail(int id)
		{
			var matchedCar = _carService.GetCar(id);

			return View(matchedCar);
		}

		
		[HttpPost]
		public ActionResult Detail(CarViewModel postData)
		{
			if (ModelState.IsValid)
			{
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