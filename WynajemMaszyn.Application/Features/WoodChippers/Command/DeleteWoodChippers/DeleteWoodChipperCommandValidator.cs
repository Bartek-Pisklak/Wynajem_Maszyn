using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Application.Features.WoodChippers.Command.CreateWoodChippers;

namespace WynajemMaszyn.Application.Features.WoodChippers.Command.DeleteWoodChippers
{
    public class DeleteWoodChipperCommandValidator : AbstractValidator<DeleteWoodChipperCommand>
    {

        public DeleteWoodChipperCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required");
        }
    }
}
