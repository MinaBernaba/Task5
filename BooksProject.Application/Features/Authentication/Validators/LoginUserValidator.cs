using BooksProject.Application.Features.Authentication.Models;
using FluentValidation;

namespace BooksProject.Application.Features.Authentication.Validators
{
    public class LoginUserValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserValidator()
        {
            ApplyValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(X => X.UserName)
                .NotEmpty().WithMessage("Username can't be empty!")
                .WithErrorCode("400");

            RuleFor(X => X.Password)
                .NotEmpty().WithMessage("Password can't be empty!")
                .WithErrorCode("400");;

        }
    }
}
