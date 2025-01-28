using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Application.Features.MachineryRentals.Command.DeleteMachineryCard;

namespace WynajemMaszyn.Application.Features.MachineryRentals.Command.EditMachineRentals
{
    public class EditMachineryRentalCommandValidator : AbstractValidator<EditMachineryRentalCommand>
    {
        public EditMachineryRentalCommandValidator()
        {

        }
    }
}


/*
        RuleFor(x => x.IdMachine)
                .NotEmpty().WithMessage("id machine is required");
        RuleFor(x => x.TypeMachine)
                .NotEmpty().WithMessage("TypeMachine is required")
                .Must(value => new[] { "Excavator", "ExcavatorBucket", "Roller", "Harvester", "WoodChipper" }.Contains(value))
                .WithMessage("TypeMachine must be one of the following: Excavator,ExcavatorBucket, Roller, Harvester, WoodChipper");
*/