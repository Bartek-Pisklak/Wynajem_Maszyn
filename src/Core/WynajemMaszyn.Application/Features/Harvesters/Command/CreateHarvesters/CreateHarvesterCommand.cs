using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.HarversterAnswer;
using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.Features.Harvesters.Command.CreateHarvesters
{
    public record CreateHarvesterCommand
    (
        string Name,
        int ProductionYear,
        int OperatingHours,
        int Weight,
        string Engine,
        int EnginePower,
        int DrivingSpeed,
        FuelType FuelType,
        int FuelConsumption,
        int MaxSpeed,
        int CuttingDiameter,
        int MaxReach,
        string WheelType,
        float RentalPricePerDay,
        string ImagePath,
        string Description

        ) : IRequest<ErrorOr<HarvesterResponse>>;
}
