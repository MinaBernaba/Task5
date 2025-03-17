using BooksProject.Application.Features.Books.Queries.Handler;
using BooksProject.Application.Features.Books.Queries.Models;
using BooksProject.Application.Features.Books.Queries.Responses;
using BooksProject.Application.ResponseBase;
using BooksProject.Application.ServiceInterfaces;
using FakeItEasy;
using FluentAssertions;
using System.Net;

namespace BooksProject.Tests.BookQueryHandlerTests.Commands
{
    public class BookQueryHandlerTestsUsingFakeItEasy
    {
        [Fact]
        public async Task HandleGetAllBooksQueryRequest_WhenRequestObjectIsValid_ListOfBooksInfoShouldBeReturned()
        {
            // Arrange
            var bookServiceMock = A.Fake<IBookService>();

            A.CallTo(() => bookServiceMock.GetAllBooksAsync()).Returns(new List<BookMainInfoResponse>()
            {
                new BookMainInfoResponse()
                {
                    Title = "Book1"
                }
            });

            var handler = new BookQueryHandler(bookServiceMock);

            var getAllBooksQuery = A.Fake<GetAllBooksQuery>();

            // Act

            var result = await handler.Handle(getAllBooksQuery, default);

            // Assert

            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Should().BeOfType<Response<List<BookMainInfoResponse>>>();

        }
        [Fact]
        public async Task HandleGetBookByIdQuery_WhenBookIdIsExist_ShouldReturnTheBookInfo()
        {
            // Arrange
            var bookServiceMock = A.Fake<IBookService>();

            A.CallTo(() => bookServiceMock.IsExistAsync(A<int>.Ignored)).Returns(true);

            A.CallTo(() => bookServiceMock.GetBookByIdAsync(A<int>.Ignored)).Returns(new BookMainInfoResponse()
            {
                Title = "Book1"
            });

            var handler = new BookQueryHandler(bookServiceMock);

            var getBookByIdQuery = A.Fake<GetBookByIdQuery>();


            // Act
            var result = await handler.Handle(getBookByIdQuery, default);


            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Should().BeOfType<Response<BookMainInfoResponse>>();
        }
        [Fact]
        public async Task HandleGetBookByIdQueryRequest_WhenBookIdIsNotExist_ShouldReturnNotFoundResponse()
        {
            // Arrange
            var bookServiceMock = A.Fake<IBookService>();

            A.CallTo(() => bookServiceMock.IsExistAsync(A<int>.Ignored)).Returns(false);

            var getBookByIdQuery = A.Fake<GetBookByIdQuery>();

            var handler = new BookQueryHandler(bookServiceMock);

            // Act
            var result = await handler.Handle(getBookByIdQuery, default);

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
            result.Data.Should().BeNull();
            result.Message.Should().Be($"Book with ID: {getBookByIdQuery.BookId} not found");
        }
    }
}
