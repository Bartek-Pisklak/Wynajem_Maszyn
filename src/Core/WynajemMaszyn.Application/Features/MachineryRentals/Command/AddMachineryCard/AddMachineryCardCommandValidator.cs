using FluentValidation;


namespace WynajemMaszyn.Application.Features.MachineryRentals.Command.AddMachineryCard
{
    public class AddMachineryCardCommandValidator : AbstractValidator<AddMachineryCardCommand>
    {
        public AddMachineryCardCommandValidator()
        {
            RuleFor(x => x.IdMachine)
                .NotEmpty().WithMessage("id machine is required");
            RuleFor(x => x.TypeMachine)
                .NotEmpty().WithMessage("TypeMachine is required")
                .Must(value => new[] { "Excavator","ExcavatorBucket", "Roller", "Harvester", "WoodChipper" }.Contains(value))
                .WithMessage("TypeMachine must be one of the following: Excavator,ExcavatorBucket, Roller, Harvester, WoodChipper");
        }
    }
}
