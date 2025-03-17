using AutoMapper;
using BooksProject.Application.Features.Books.Commands.Handler;
using BooksProject.Application.Features.Books.Commands.Models;
using BooksProject.Application.Mapping.BookMapper;
using BooksProject.Application.ResponseBase;
using BooksProject.Application.ServiceInterfaces;
using BooksProject.Data.Entities;
using FluentAssertions;
using Moq;
using System.Net;

namespace BooksProject.Tests.BooksTests.BookCommandHandlerTests
{
    public class BookCommandHandlerTests
    {
        private readonly IMapper _mapper;
        public BookCommandHandlerTests()
        {
            var configration = new MapperConfiguration(x => x.AddProfile<BookProfile>());
            _mapper = new Mapper(configration);
        }
        [Fact]
        public async Task HandleAddBookCommandRequest_WhenAddBookCommandObjectIsValid_ShouldReturnCreatedStatusCode()
        {
            // Arrange
            var bookservice = new Mock<IBookService>();

            bookservice.Setup(x => x.AddBookAsync(It.IsAny<Book>())).Returns(Task.FromResult(true));

            var handler = new BookCommandHandler(bookservice.Object, _mapper);
            var request = new AddBookCommand()
            {
                Title = "Book1"
            };

            // Act
            var result = await handler.Handle(request, default);

            // Assert

            result.StatusCode.Should().Be(HttpStatusCode.Created);
            result.Should().NotBeNull();
            result.Should().BeOfType<Response<string>>();
        }

        [Fact]
        public async Task HandleAddBookCommandRequest_WhenAddBookCommandObjectIsNotValid_ShouldReturnBadRequestStatusCode()
        {
            // Arrange
            var bookservice = new Mock<IBookService>();

            bookservice.Setup(x => x.AddBookAsync(It.IsAny<Book>())).Returns(Task.FromResult(false));

            var handler = new BookCommandHandler(bookservice.Object, _mapper);

            var request = new AddBookCommand()
            {
                Title = "Book1"
            };

            // Act
            var result = await handler.Handle(request, default);

            // Assert

            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            result.Should().NotBeNull();
            result.Should().BeOfType<Response<string>>();
        }

        [Fact]
        public async Task HandleUpdateBookCommandRequest_WhenUpdateBookCommandObjectIsValid_ShouldReturnOkStatusCode()
        {
            // Arrange
            var bookservice = new Mock<IBookService>();

            bookservice.Setup(x => x.UpdateBookAsync(It.IsAny<Book>())).Returns(Task.FromResult(true));

            var handler = new BookCommandHandler(bookservice.Object, _mapper);

            var request = new UpdateBookCommand()
            {
                BookId = 1,
                Title = "Book1"
            };

            // Act
            var result = await handler.Handle(request, default);

            // Assert

            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().NotBeNull();
            result.Should().BeOfType<Response<string>>();
        }

        [Fact]
        public async Task HandleUpdateBookCommandRequest_WhenUpdateBookCommandObjectIsNotValid_ShouldReturnBadRequestStatusCode()
        {
            // Arrange
            var bookservice = new Mock<IBookService>();

            bookservice.Setup(x => x.UpdateBookAsync(It.IsAny<Book>())).Returns(Task.FromResult(false));

            var handler = new BookCommandHandler(bookservice.Object, _mapper);

            var request = new UpdateBookCommand()
            {
                BookId = 1,
                Title = "Book1"
            };

            // Act
            var result = await handler.Handle(request, default);

            // Assert

            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            result.Should().NotBeNull();
            result.Should().BeOfType<Response<string>>();
        }

        [Fact]
        public async Task HandleDeleteBookCommandRequest_WhenBookIdIsValid_ShouldReturnOkStatusCode()
        {
            // Arrange
            var bookservice = new Mock<IBookService>();

            bookservice.Setup(x => x.IsExistAsync(It.IsAny<int>())).Returns(Task.FromResult(true));

            bookservice.Setup(x => x.DeleteBookAsync(It.IsAny<int>())).Returns(Task.FromResult(true));

            var handler = new BookCommandHandler(bookservice.Object, _mapper);

            var request = new DeleteBookCommand()
            {
                BookId = 1
            };

            // Act
            var result = await handler.Handle(request, default);

            // Assert

            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().NotBeNull();
            result.Should().BeOfType<Response<string>>();
        }

        [Fact]
        public async Task HandleDeleteBookCommandRequest_WhenBookIdIsNotValid_ShouldReturnNotFoundStatusCode()
        {
            // Arrange
            var bookservice = new Mock<IBookService>();

            bookservice.Setup(x => x.IsExistAsync(It.IsAny<int>())).Returns(Task.FromResult(false));

            bookservice.Setup(x => x.DeleteBookAsync(It.IsAny<int>())).Returns(Task.FromResult(false));

            var handler = new BookCommandHandler(bookservice.Object, _mapper);

            var request = new DeleteBookCommand()
            {
                BookId = 1
            };

            // Act
            var result = await handler.Handle(request, default);

            // Assert

            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
            result.Should().NotBeNull();
            result.Should().BeOfType<Response<string>>();
        }
    }
}
