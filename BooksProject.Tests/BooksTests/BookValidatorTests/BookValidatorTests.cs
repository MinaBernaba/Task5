using BooksProject.Application.Features.Books.Commands.Models;
using FluentValidation.TestHelper;

namespace BooksProject.Tests.BooksTests.BookValidatorTests
{
    public class AddBookValidatorTests
    {
        private readonly AddBookValidator _validator;

        public AddBookValidatorTests()
        {
            _validator = new AddBookValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_Have_Error_When_Title_Is_Null_Or_Empty(string title)
        {
            // Arrange
            var model = new AddBookCommand { Title = title };

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Title)
                  .WithErrorMessage("Title is required!");
        }

        [Theory]
        [InlineData("Bo")] // Less than 3 characters
        public void Should_Have_Error_When_Title_Is_Too_Short(string title)
        {
            // Arrange
            var model = new AddBookCommand { Title = title };

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Title)
                  .WithErrorMessage("Title must be at least 3 characters long!");
        }

        [Theory]
        [InlineData("This title is way too long for a valid book title because it exceeds 30 characters")]
        public void Should_Have_Error_When_Title_Is_Too_Long(string title)
        {
            // Arrange
            var model = new AddBookCommand { Title = title };

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Title)
                  .WithErrorMessage("Title must not be longer than 30 characters!");
        }

        [Theory]
        [InlineData("Valid Title")]
        [InlineData("Another Valid Title")]
        public void Should_Not_Have_Error_When_Title_Is_Valid(string title)
        {
            // Arrange
            var model = new AddBookCommand { Title = title };

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Title);
        }
    }

}
