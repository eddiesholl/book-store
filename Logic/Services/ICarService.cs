using CarSales.Data.Domain;
using CarSales.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSales.Logic.Services
{
	public interface ICarService : IService
	{
		IEnumerable<CarListModel> GetAllCars();
		CarViewModel GetCar(int carID);
	}
}
