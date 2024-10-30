using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WynajemMaszyn.Application.Features.MachineryRentals.Command.CreateMachineRentals
{
    public class CreateMachineRentalCommandValidator : AbstractValidator<CreateMachineRentalCommand>
    {
        public CreateMachineRentalCommandValidator() 
        {
            /*RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required");*/

        }
    }
}
