using BookSales.Data.Models;
using BookSales.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookSales.Presentation.Controllers
{
	public class BooksController : Controller
	{
		IBookService _bookService;
		IEnquiryService _enquiryService;
		public BooksController(IBookService bookService, IEnquiryService enquiryService)
		{
			_bookService = bookService;
			_enquiryService = enquiryService;
		}

		public ActionResult List()
		{
			var allBooks = _bookService.GetAllBooks().ToList();

			return View(allBooks);
		}

		[HttpGet]
		public ActionResult Detail(int bookID)
		{
			var matchedBook = _bookService.GetBook(bookID);

			return View(matchedBook);
		}

		
		[HttpPost]
		public ActionResult Detail(BookViewModel postData)
		{
			if (ModelState.IsValid)
			{
				// Save the enquiry details to persistence etc
				_enquiryService.RecordEnquiry(postData.EnquireName, postData.EnquireEmail, postData.BookID);

				return RedirectToAction("Enquire", new { bookID = postData.BookID });
			}
			else
			{
				return View(postData);
			}
		}

		public ActionResult Enquire(int bookID)
		{
			var matchedBook = _bookService.GetBook(bookID);

			return View(matchedBook);
		}
	}
}