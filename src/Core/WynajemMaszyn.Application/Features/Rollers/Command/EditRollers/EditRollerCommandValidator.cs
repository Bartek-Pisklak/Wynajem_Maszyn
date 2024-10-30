using FluentValidation;


namespace WynajemMaszyn.Application.Features.Rollers.Command.EditRollers
{
    public class EditRollerCommandValidator : AbstractValidator<EditRollerCommand>
    {

        public EditRollerCommandValidator()
        {
            RuleFor(x => x.Id)
                        .NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Name)
                        .NotEmpty().WithMessage("Name is required");
        }
    }
}
