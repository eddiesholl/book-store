using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSales.Data.Domain
{
	public enum PriceType
	{
		POA,
		DAP,
		EGC
	}

	/// <summary>
	/// Wrapper class for modelling the different pricing models available on a car
	/// </summary>
	public class Price
	{
		public PriceType PriceType { get; private set; }
		public decimal? PriceAmount { get; private set; }

		public Price()
		{
			PriceType = Domain.PriceType.POA;
			PriceAmount = null;
		}

		public Price(PriceType priceType = Domain.PriceType.POA, decimal? price = null)
		{
			PriceType = priceType;
			PriceAmount = price;
		}
	}
}
