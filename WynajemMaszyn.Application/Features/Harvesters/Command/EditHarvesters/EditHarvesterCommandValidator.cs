using FluentValidation;

namespace WynajemMaszyn.Application.Features.Harvesters.Command.EditHarvesters
{
    public class EditHarvesterCommandValidator : AbstractValidator<EditHarvesterCommand>
    {

        public EditHarvesterCommandValidator()
        {
            RuleFor(x => x.Id)
                          .NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Name)
                          .NotEmpty().WithMessage("Name is required");
        }
    }
}
