using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.ExcavatorAnswer;

namespace WynajemMaszyn.Application.Features.Excavators.Command.CreateExcavators
{
    public record CreateExcavatorCommand
    (
    int Id,
    int IdUser,
    string Name,
    DateTime ProductionYear,
    int OperatingHours,
    int Weight,
    int Engine,
    int EnginePower,
    int DrivingSpeed,
    string Description

                ) : IRequest<ErrorOr<ExcavatorResponse>>;


}
