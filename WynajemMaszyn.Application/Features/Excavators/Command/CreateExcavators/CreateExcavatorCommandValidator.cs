using FluentValidation;


namespace WynajemMaszyn.Application.Features.Excavators.Command.CreateExcavators
{
    public class CreateExcavatorCommandValidator : AbstractValidator<CreateExcavatorCommand>
    {
        public CreateExcavatorCommandValidator() {
            RuleFor(x => x.Name)
                     .NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Engine)
                .NotEmpty().WithMessage("Engine is required");
        }

        // co musi miec by dodac inaczej blad
    }

}
