using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.RollerAnswer;

namespace WynajemMaszyn.Application.Features.Rollers.Command.CreateRollers
{
    public record CreateRollerCommand
    (
    int Id,
    int IdUser,
    string Name,
    DateTime ProductionYear,
    int Weight,
    string Description

    ) : IRequest<ErrorOr<RollerResponse>>;


}
