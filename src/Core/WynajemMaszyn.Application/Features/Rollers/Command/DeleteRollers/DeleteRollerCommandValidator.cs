﻿using FluentValidation;

namespace WynajemMaszyn.Application.Features.Rollers.Command.DeleteRollers
{
    public class DeleteRollerCommandValidator : AbstractValidator<DeleteRollerCommand>
    {
        public DeleteRollerCommandValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required");
        }
    }
}
