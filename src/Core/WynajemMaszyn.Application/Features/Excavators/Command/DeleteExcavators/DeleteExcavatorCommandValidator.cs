using FluentValidation;

namespace WynajemMaszyn.Application.Features.Excavators.Command.DeleteExcavators
{
    public class DeleteExcavatorCommandValidator : AbstractValidator<DeleteExcavatorCommand> 
    {
        public DeleteExcavatorCommandValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required");
        }
    }
}
