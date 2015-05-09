using BookSales.Data.Domain;
using BookSales.Data.Models;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSales.Logic.Services
{
	public class BookService : IBookService
	{
		static List<Book> _privateStock = new List<Book>();
		static List<Book> _dealerStock = new List<Book>();
		private IEnumerable<Book> AllStock { get { return _privateStock.Union(_dealerStock).OrderBy(c => c.Author); } }

		/// <summary>
		/// Auto populate some static sample data for stock
		/// </summary>
		static BookService()
		{
			var fixture = new Fixture();
			fixture.Customizations.Add(
				new StringGenerator(() =>
					Guid.NewGuid().ToString().Substring(0, 10)));

			fixture.Register<Price>(() => SampleDataGenerator.GetRandomPrice());
			fixture.Register<int>(() => SampleDataGenerator.GetRandomYear());

			fixture.AddManyTo(_privateStock, 10);
			_privateStock.ForEach(c =>
				{
					c.MakePrivateListing();
				});

			fixture.AddManyTo(_dealerStock, 10);
			_dealerStock.ForEach(c =>
				{
					c.MakeDealerListing();
				});
		}

		#region IBookService
		public IEnumerable<BookListModel> GetAllBooks()
		{
			return AllStock.Select(c => ConvertToListModel(c));
		}

		public BookViewModel GetBook(Int64 bookID)
		{
			BookViewModel result = null;

			var matchedBook = AllStock.FirstOrDefault(c => c.BookID == bookID);

			if (matchedBook != null)
			{
				result = ConvertToViewModel(matchedBook);
			}

			return result;
		}
		#endregion

		private BookListModel ConvertToListModel(Book book)
		{
			var result = new BookListModel
			{
				BookID = book.BookID,
				Author = book.Author,
				Title = book.Title,
				Comments = book.Comments,
				Email = book.Email,
				Price = book.Price,
				Year = book.Year
			};
			return result;
		}

		private BookViewModel ConvertToViewModel(Book book)
		{
			var result = new BookViewModel
			{
				BookID = book.BookID,
				Author = book.Author,
				Title = book.Title,
				Comments = book.Comments,
				Email = book.Email,
				PriceAmount = book.Price.PriceAmount,
				PriceType = book.Price.PriceType,
				Year = book.Year,
				ListingType = book.ListingType,
				ContactName = book.ContactName,
				Phone = book.Phone,
				ABN = book.ABN
			};

			return result;
		}
	}
}
