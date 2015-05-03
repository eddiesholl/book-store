using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSales.Data.Domain
{
	public class SampleDataGenerator
	{
		static List<Tuple<string, string>> _sampleModels;
		static Random _rnd;

		static SampleDataGenerator()
		{
			// REVISIT Hook up sample data generation so it pulls in real names from here
			_sampleModels = new List<Tuple<string, string>>()
			{
				Tuple.Create( "Hyundai", "i20"),
				Tuple.Create( "Ford", "Fiesta"),
				Tuple.Create( "Mclaren", "F1")
			};

			_rnd = new Random();
		}

		public static Price GetRandomPrice()
		{
			decimal price = 15000 + _rnd.Next(10000);
			int typeGen = _rnd.Next(0, 2);
			PriceType randomPriceType = (PriceType)typeGen;

			var result = new Price(randomPriceType, randomPriceType == PriceType.POA ? (decimal?)null : price);
			
			return result;
		}

		public static int GetRandomYear()
		{
			return _rnd.Next(1995, 2015);
		}
	}
}
