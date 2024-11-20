using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.HarversterAnswer;
using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.Features.Harvesters.Command.EditHarvesters
{
    public record EditHarvesterCommand
    (
        int Id,
        string Name,
        int ProductionYear,
        int OperatingHours,
        int Weight,
        int EnginePower,
        FuelType FuelType,
        int FuelConsumption,
        int MaxSpeed,
        int CuttingDiameter,
        int MaxReach,
        string WheelType,
        float RentalPricePerDay,
        string ImagePath,
        string Description,
        bool IsRepair

        ) : IRequest<ErrorOr<HarvesterResponse>>;
}
