using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Application.Features.MachineryRentals.Command.AddMachineryCard;

namespace WynajemMaszyn.Application.Features.MachineryRentals.Command.DeleteMachineryCard
{
    public class DeleteMachineryCardCommandValidator : AbstractValidator<DeleteMachineryCardCommand>
    {
        public DeleteMachineryCardCommandValidator()
        {
            RuleFor(x => x.IdMachine)
                    .NotEmpty().WithMessage("id machine is required");
            RuleFor(x => x.TypeMachine)
                    .NotEmpty().WithMessage("TypeMachine is required")
                    .Must(value => new[] { "Excavator", "ExcavatorBucket", "Roller", "Harvester", "WoodChipper" }.Contains(value))
                    .WithMessage("TypeMachine must be one of the following: Excavator,ExcavatorBucket, Roller, Harvester, WoodChipper");
        }
    }
}
