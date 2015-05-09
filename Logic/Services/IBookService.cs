using BookSales.Data.Domain;
using BookSales.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSales.Logic.Services
{
	public interface IBookService : IService
	{
		IEnumerable<BookListModel> GetAllBooks();
		BookViewModel GetBook(int bookID);
	}
}
