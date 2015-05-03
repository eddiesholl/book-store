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

	public class Price
	{
		public PriceType PriceType { get; private set; }
		public decimal? PriceAmount { get; private set; }

		public Price(PriceType priceType, decimal? price = null)
		{
			PriceType = priceType;
			PriceAmount = price;
		}
	}
}
