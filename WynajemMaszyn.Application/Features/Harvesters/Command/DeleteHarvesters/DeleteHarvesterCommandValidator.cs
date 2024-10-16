using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Application.Features.Harvesters.Command.CreateHarvesters;

namespace WynajemMaszyn.Application.Features.Harvesters.Command.DeleteHarvesters
{
    public class DeleteHarvesterCommandValidator : AbstractValidator<DeleteHarvesterCommand>
    {

        public DeleteHarvesterCommandValidator() 
        {
            RuleFor(x => x.Id)
                          .NotEmpty().WithMessage("Id is required");
        }
    }
}
