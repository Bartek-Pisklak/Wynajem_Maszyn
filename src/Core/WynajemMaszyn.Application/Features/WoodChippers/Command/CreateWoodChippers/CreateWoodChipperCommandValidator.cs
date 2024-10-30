using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WynajemMaszyn.Application.Features.WoodChippers.Command.CreateWoodChippers
{
    public class CreateWoodChipperCommandValidator : AbstractValidator<CreateWoodChipperCommand>
    {
        public CreateWoodChipperCommandValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required");
        }
    }
}
