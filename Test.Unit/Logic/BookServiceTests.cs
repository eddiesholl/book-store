using BookSales.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using BookSales.Data.Models;

namespace Test.Unit.Logic
{
	public class BookServiceTests
	{
		BookService sut;
		List<BookListModel> allBooks;

		public BookServiceTests()
		{
			sut = new BookService();
			allBooks = sut.GetAllBooks().ToList();
		}

		[Fact]
		public void GetAllBooks_ReturnsSomething()
		{
			allBooks.ShouldNotBe(null);
			allBooks.Count.ShouldBeGreaterThan(0);
		}

		[Fact]
		public void GetBook_Exists()
		{
			var firstBook = allBooks.First();
			var lastBook = allBooks.Last();

			var firstResult = sut.GetBook(firstBook.BookID);
			var lastResult = sut.GetBook(lastBook.BookID);

			firstResult.BookID.ShouldBe(firstBook.BookID);
			lastResult.BookID.ShouldBe(lastBook.BookID);
		}

		[Fact]
		public void GetBook_NotExists()
		{
			// Find an id that is not an existing book
			int notValidID = int.MinValue;

			do
			{
				notValidID++;
			}
			while (allBooks.Any(b => b.BookID == notValidID));

			var result = sut.GetBook(notValidID);
			result.ShouldBe(null);
		}
	}
}
