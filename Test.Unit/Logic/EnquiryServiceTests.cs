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
	public class EnquiryServiceTests
	{
		EnquiryService sut;

		public EnquiryServiceTests()
		{
			sut = new EnquiryService();
		}

		[Fact]
		public void GetAllEnquiries_Empty()
		{
			var result = sut.GetAllEnquiries().ToList();

			result.ShouldNotBe(null);
			result.Count.ShouldBe(0);
		}

		[Theory]
		[InlineData("name", "email", 5, 1)]
		[InlineData("with space", "blah", 500, 2)]
		public void RecordEnquiry_StoresResults(string name, string email, int bookID, int count)
		{
			sut.RecordEnquiry(name, email, bookID);

			var result = sut.GetAllEnquiries().ToList();

			result.ShouldNotBe(null);
			result.Count.ShouldBe(count);
			var lastEnquiry = result.Last();
			lastEnquiry.BookID.ShouldBe(bookID);
			lastEnquiry.Name.ShouldBe(name);
			lastEnquiry.Email.ShouldBe(email);
		}
	}
}
