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

		public ActionResult View(int carID)
		{
			var matchedCar = _carService.GetCar(carID);

			return View(matchedCar);
		}
	}
}