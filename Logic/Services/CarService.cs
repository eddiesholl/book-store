using CarSales.Data.Domain;
using CarSales.Data.Models;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSales.Logic.Services
{
	public class CarService : ICarService
	{
		static List<Car> _privateCars = new List<Car>();
		static List<Car> _dealerCars = new List<Car>();
		private IEnumerable<Car> AllCars { get { return _privateCars.Union(_dealerCars).OrderBy(c => c.Make); } }

		/// <summary>
		/// Auto populate some static sample data for cars
		/// </summary>
		static CarService()
		{
			var fixture = new Fixture();
			fixture.Customizations.Add(
				new StringGenerator(() =>
					Guid.NewGuid().ToString().Substring(0, 10)));

			fixture.Register<Price>(() => SampleDataGenerator.GetRandomPrice());
			fixture.Register<int>(() => SampleDataGenerator.GetRandomYear());

			fixture.AddManyTo(_privateCars, 10);
			_privateCars.ForEach(c =>
				{
					c.MakePrivateListing();
				});

			fixture.AddManyTo(_dealerCars, 10);
			_dealerCars.ForEach(c =>
				{
					c.MakeDealerListing();
				});
		}

		#region ICarService
		public IEnumerable<CarListModel> GetAllCars()
		{
			return AllCars.Select(c => ConvertCarToListModel(c));
		}

		public CarViewModel GetCar(int carID)
		{
			CarViewModel result = null;

			var matchedCar = AllCars.FirstOrDefault(c => c.CarID == carID);

			if (matchedCar != null)
			{
				result = ConvertCarToViewModel(matchedCar);
			}

			return result;
		}
		#endregion

		private CarListModel ConvertCarToListModel(Car car)
		{
			var result = new CarListModel
			{
				CarID = car.CarID,
				Make = car.Make,
				Model = car.Model,
				Comments = car.Comments,
				Email = car.Email,
				Price = car.Price,
				Year = car.Year
			};
			return result;
		}

		private CarViewModel ConvertCarToViewModel(Car car)
		{
			var result = new CarViewModel
			{
				CarID = car.CarID,
				Make = car.Make,
				Model = car.Model,
				Comments = car.Comments,
				Email = car.Email,
				PriceAmount = car.Price.PriceAmount,
				PriceType = car.Price.PriceType,
				Year = car.Year,
				ListingType = car.ListingType,
				ContactName = car.ContactName,
				Phone = car.Phone,
				ABN = car.ABN
			};

			return result;
		}
	}
}
