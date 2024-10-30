using FluentValidation;

namespace WynajemMaszyn.Application.Features.Rollers.Command.CreateRollers
{
    public class CreateRollerCommandValidator : AbstractValidator<CreateRollerCommand>
    {
        public CreateRollerCommandValidator()
        {
            RuleFor(x => x.Name)
                       .NotEmpty().WithMessage("Name is required");
        }
    }
}
