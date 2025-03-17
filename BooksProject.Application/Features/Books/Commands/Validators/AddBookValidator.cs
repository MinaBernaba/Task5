using BooksProject.Application.Features.Books.Commands.Models;
using FluentValidation;

public class AddBookValidator : AbstractValidator<AddBookCommand>
{

    public AddBookValidator()
    {
        ApplyValidationRules();
        ApplyCustomValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required!")
            .NotNull().WithMessage("Title is required!")
            .MaximumLength(30).WithMessage("Title must not be longer than 30 characters!")
            .MinimumLength(3).WithMessage("Title must be at least 3 characters long!");
    }

    private void ApplyCustomValidationRules()
    {

    }
}
