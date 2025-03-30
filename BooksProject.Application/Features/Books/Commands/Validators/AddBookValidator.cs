using BooksProject.Application.Features.Books.Commands.Models;
using FluentValidation;

public class AddBookValidator : AbstractValidator<AddBookCommand>
{

    public AddBookValidator()
    {
        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required!")
            .WithErrorCode("400")
            .MaximumLength(30).WithMessage("Title must not be longer than 30 characters!")
            .WithErrorCode("400")
            .MinimumLength(3).WithMessage("Title must be at least 3 characters long!")
            .WithErrorCode("400");
    }
}
