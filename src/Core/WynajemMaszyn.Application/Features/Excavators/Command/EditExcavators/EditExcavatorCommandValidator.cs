using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WynajemMaszyn.Application.Features.Excavators.Command.EditExcavators
{
    public class EditExcavatorCommandValidator : AbstractValidator<EditExcavatorCommand>
    {
        public EditExcavatorCommandValidator() 
        {
            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required");
        }

    }
}
