using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.RollerAnswer;

namespace WynajemMaszyn.Application.Features.Rollers.Command.EditRollers
{
    public record EditRollerCommand
    (
    int Id,
    string Name,
    int ProductionYear,
    int OperatingHours,
    int Weight,
    int Engine,
    int EnginePower,
    int DrivingSpeed,
    int FuelConsumption,
    string FuelType,
    string Gearbox,
    int NumberOfDrums,
    string RollerType,
    int DrumWidth,
    int MaxCompactionForce,
    bool IsVibratory,
    bool KnigeAsfalt,
    float RentalPricePerDay,
    string ImagePath,
    string Description

    ) : IRequest<ErrorOr<RollerResponse>>;
}
