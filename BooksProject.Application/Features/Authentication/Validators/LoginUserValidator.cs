using BooksProject.Application.Features.Authentication.Models;
using FluentValidation;

namespace BooksProject.Application.Features.Authentication.Validators
{
    public class LoginUserValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserValidator()
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(X => X.UserName)
                .NotNull().WithMessage("Username can't be null!")
                .NotEmpty().WithMessage("Username can't be empty!");

            RuleFor(X => X.Password)
                .NotNull().WithMessage("Password can't be null!")
                .NotEmpty().WithMessage("Password can't be empty!");

        }
        public void ApplyCustomValidationRules()
        {

        }
    }
}
