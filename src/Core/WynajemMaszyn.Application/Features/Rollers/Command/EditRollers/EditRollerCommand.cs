using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.RollerAnswer;
using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.Features.Rollers.Command.EditRollers
{
    public record EditRollerCommand
    (
        int Id,
        string Name,
        int ProductionYear,
        int OperatingHours,
        int Weight,
        string Engine,
        int EnginePower,
        int DrivingSpeed,
        int FuelConsumption,
        FuelType FuelType,
        string Gearbox,
        int NumberOfDrums,
        RollerType RollerType,
        int DrumWidth,
        int MaxCompactionForce,
        bool IsVibratory,
        bool KnigeAsfalt,
        float RentalPricePerDay,
        string ImagePath,
        string Description,
        bool IsRepair
    ) : IRequest<ErrorOr<RollerResponse>>;
}
