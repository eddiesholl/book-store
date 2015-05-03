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

		static CarService()
		{
			var fixture = new Fixture();
			fixture.Customizations.Add(
				new StringGenerator(() =>
					Guid.NewGuid().ToString().Substring(0, 10)));

			fixture.Register<Price>(() => SampleDataGenerator.GetRandomPrice());
			fixture.Register<int>(() => SampleDataGenerator.GetRandomYear());

			fixture.Register<ContactDetails>(() => (ContactDetails)fixture.Create<PrivateContactDetails>());
			fixture.AddManyTo(_privateCars, 10);

			fixture.Register<ContactDetails>(() => (ContactDetails)fixture.Create<DealerContactDetails>());
			fixture.AddManyTo(_dealerCars, 10);
		}

		private IEnumerable<Car> AllCars { get { return _privateCars.Union(_dealerCars).OrderBy(c => c.Make); } }


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

		public CarListModel ConvertCarToListModel(Car car)
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

		public CarViewModel ConvertCarToViewModel(Car car)
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
				Year = car.Year
			};

			return result;
		}
	}
}
