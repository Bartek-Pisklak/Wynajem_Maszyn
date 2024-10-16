using FluentValidation;


namespace WynajemMaszyn.Application.Features.Harvesters.Command.CreateHarvesters
{
    public class CreateHarvesterCommandValidator : AbstractValidator<CreateHarvesterCommand>
    {
        public CreateHarvesterCommandValidator()
        {
            RuleFor(x => x.Name)
                        .NotEmpty().WithMessage("Name is required");
        }
    }

}

