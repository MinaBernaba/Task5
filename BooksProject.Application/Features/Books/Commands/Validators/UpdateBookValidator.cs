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
            .NotEmpty().WithMessage("Book ID is required!")
            .GreaterThan(0).WithMessage("Book ID must be a valid positive number!")
            .DependentRules(() =>
            {
                RuleFor(x => x.BookId)
                .MustAsync(async (bookId, cancellationToken) => await _bookService.IsExistAsync(bookId))
                .WithMessage(x => $"The Book ID: {x.BookId} does not exist!");
            });

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required!")
            .NotNull().WithMessage("Title is required!")
            .MaximumLength(30).WithMessage("Title must not be longer than 30 characters!")
            .MinimumLength(3).WithMessage("Title must be at least 3 characters long!");

    }
}
