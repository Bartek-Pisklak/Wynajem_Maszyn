using FluentValidation;

namespace WynajemMaszyn.Application.Authentication.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Please provide correct details");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Please provide correct details");
    }
}