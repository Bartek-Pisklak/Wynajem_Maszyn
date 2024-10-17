﻿using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.RollerAnswer;

namespace WynajemMaszyn.Application.Features.Rollers.Command.DeleteRollers
{
    public record DeleteRollerCommand
    (
       int Id
    ) : IRequest<ErrorOr<RollerResponse>>;
}
