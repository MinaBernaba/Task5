using BooksProject.Application.Features.Books.Commands.Models;
using BooksProject.Application.ServiceInterfaces;
using FluentValidation;

public class UpdateBookValidator : AbstractValidator<UpdateBookCommand>
{
    private readonly IBookService _bookService;

    public UpdateBookValidator(IBookService bookService)
    {
        _bookService = bookService;
        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(x => x.BookId)
            .GreaterThan(0).WithMessage("Book ID must be a valid positive number!")
            .WithErrorCode("400")
            .DependentRules(() =>
            {
                RuleFor(x => x.BookId)
                .MustAsync(async (bookId, cancellationToken) => await _bookService.IsExistAsync(bookId))
                .WithMessage(x => $"The Book ID: {x.BookId} does not exist!")
                .WithErrorCode("404");
            });

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required!")
            .WithErrorCode("400")
            .MaximumLength(30).WithMessage("Title must not be longer than 30 characters!")
            .WithErrorCode("400")
            .MinimumLength(3).WithMessage("Title must be at least 3 characters long!")
            .WithErrorCode("400");

    }
}
