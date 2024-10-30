using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Application.Features.WoodChippers.Command.DeleteWoodChippers;

namespace WynajemMaszyn.Application.Features.WoodChippers.Command.EditWoodChippers
{
    public class EditWoodChipperCommandValidator : AbstractValidator<EditWoodChipperCommand>
    {
        public EditWoodChipperCommandValidator() 
        {
            RuleFor(x => x.Id)
                   .NotEmpty().WithMessage("Id is required");


        }

    }
}
