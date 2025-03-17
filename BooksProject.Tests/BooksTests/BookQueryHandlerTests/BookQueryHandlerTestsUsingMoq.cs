using BooksProject.Application.Features.Books.Queries.Handler;
using BooksProject.Application.Features.Books.Queries.Models;
using BooksProject.Application.Features.Books.Queries.Responses;
using BooksProject.Application.ResponseBase;
using BooksProject.Application.ServiceInterfaces;
using FluentAssertions;
using Moq;
using System.Net;

namespace BooksProject.Tests.BookQueryHandlerTests.Commands
{
    public class BookQueryHandlerTestsUsingMoq
    {
        [Fact]
        public async Task HandleGetAllBooksQueryRequest_WhenRequestObjectIsValid_ListOfBooksInfoShouldBeReturned()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();

            bookServiceMock.Setup(x => x.GetAllBooksAsync()).ReturnsAsync(new List<BookMainInfoResponse>()
            {
                new BookMainInfoResponse()
                {
                    Title = "Book1"
                }
            });

            var getAllBooksQuery = new Mock<GetAllBooksQuery>();

            var handler = new BookQueryHandler(bookServiceMock.Object);

            // Act

            var result = await handler.Handle(getAllBooksQuery.Object, default);

            // Assert

            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Should().BeOfType<Response<List<BookMainInfoResponse>>>();

        }
        [Fact]
        public async Task HandleGetBookByIdQueryRequest_WhenBookIdIsExist_ShouldReturnTheBookInfo()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();

            bookServiceMock.Setup(x => x.IsExistAsync(It.IsAny<int>())).ReturnsAsync(true);

            bookServiceMock.Setup(x => x.GetBookByIdAsync(It.IsAny<int>())).ReturnsAsync(new BookMainInfoResponse()
            {
                Title = "Book1"
            });

            var getBookByIdQuery = new Mock<GetBookByIdQuery>();
            var handler = new BookQueryHandler(bookServiceMock.Object);

            // Act
            var result = await handler.Handle(getBookByIdQuery.Object, default);

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Should().BeOfType<Response<BookMainInfoResponse>>();
        }

        [Fact]
        public async Task HandleGetBookByIdQueryRequest_WhenBookIdIsNotExist_ShouldReturnNotFound404Response()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();

            bookServiceMock.Setup(x => x.IsExistAsync(It.IsAny<int>())).ReturnsAsync(false);


            var getBookByIdQuery = new Mock<GetBookByIdQuery>();

            var handler = new BookQueryHandler(bookServiceMock.Object);

            // Act
            var result = await handler.Handle(getBookByIdQuery.Object, default);

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
            result.Data.Should().BeNull();
            result.Should().BeOfType<Response<BookMainInfoResponse>>();
        }
    }
}
