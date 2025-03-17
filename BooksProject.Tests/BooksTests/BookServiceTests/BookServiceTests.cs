using BooksProject.Application.Services;
using BooksProject.Data.Entities;
using BooksProject.Infrastructure.Interfaces;
using FluentAssertions;
using Moq;
using System.Linq.Expressions;

namespace BooksProject.Tests.BooksTests.BookServiceTests
{
    public class BookServiceTests
    {
        private readonly Mock<IBookRepository> _bookRepositoryMock;
        private readonly BookService _bookService;

        public BookServiceTests()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();
            _bookService = new BookService(_bookRepositoryMock.Object);
        }

        [Fact]
        public async Task IsBookExistByTitleAsync_WhenBookIdNotExist_ShouldReturnFalse()
        {
            // Arrange
            _bookRepositoryMock
                .Setup(repo => repo.IsExistAsync(It.IsAny<Expression<Func<Book, bool>>>()))
                .ReturnsAsync(false);

            // Act
            var result = await _bookService.IsBookExistByTitleAsync("Book 1");

            // Assert
            result.Should().BeFalse();
        }
        [Fact]
        public async Task IsBookExistByTitleAsync_WhenBookExists_ShouldReturnTrue()
        {
            // Arrange
            _bookRepositoryMock
                .Setup(repo => repo.IsExistAsync(It.IsAny<Expression<Func<Book, bool>>>()))
                .ReturnsAsync(true);

            // Act
            var result = await _bookService.IsBookExistByTitleAsync("Book 1");

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task IsBookExistByTitleAsync_WhenBookNotExists_ShouldReturnFalse()
        {
            // Arrange
            _bookRepositoryMock
                .Setup(repo => repo.IsExistAsync(It.IsAny<Expression<Func<Book, bool>>>()))
                .ReturnsAsync(false);

            // Act
            var result = await _bookService.IsBookExistByTitleAsync("Book 1");

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async Task IsExistAsync_WhenBookIdExists_ShouldReturnTrue()
        {
            // Arrange
            _bookRepositoryMock
                .Setup(repo => repo.IsExistAsync(It.IsAny<Expression<Func<Book, bool>>>()))
                .ReturnsAsync(true);

            // Act
            var result = await _bookService.IsExistAsync(1);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task IsExistAsync_WhenBookIdNotExists_ShouldReturnFalse()
        {
            // Arrange
            _bookRepositoryMock
                .Setup(repo => repo.IsExistAsync(It.IsAny<Expression<Func<Book, bool>>>()))
                .ReturnsAsync(false);

            // Act
            var result = await _bookService.IsExistAsync(1);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async Task AddBookAsync_WhenCalled_ShouldReturnTrue()
        {
            // Arrange
            var book = new Book { Title = "Book 1" };

            _bookRepositoryMock
                .Setup(repo => repo.AddAsync(It.IsAny<Book>()))
                .ReturnsAsync(true);

            // Act
            var result = await _bookService.AddBookAsync(book);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task UpdateBookAsync_WhenCalled_ShouldReturnTrue()
        {
            // Arrange
            var book = new Book { BookId = 1, Title = "Updated Book" };

            _bookRepositoryMock
                .Setup(repo => repo.UpdateAsync(It.IsAny<Book>()))
                .ReturnsAsync(true);

            // Act
            var result = await _bookService.UpdateBookAsync(book);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task DeleteBookAsync_WhenBookExists_ShouldReturnTrue()
        {
            // Arrange
            var bookId = 1;
            var book = new Book { BookId = bookId };

            _bookRepositoryMock
                .Setup(repo => repo.GetByIdAsync(bookId))
                .ReturnsAsync(book);

            _bookRepositoryMock
                .Setup(repo => repo.DeleteAsync(book))
                .ReturnsAsync(true);

            // Act
            var result = await _bookService.DeleteBookAsync(bookId);

            // Assert
            result.Should().BeTrue();
        }
    }
}