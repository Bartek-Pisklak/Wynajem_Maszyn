using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using WynajemMaszyn.Application.Contracts.HarversterAnswer;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.Features.Harvesters.Command.EditHarvesters
{
    public record EditHarvesterCommand
    (
        HttpContext context,
        int Id,
        string Name,
        int ProductionYear,
        int OperatingHours,
        int Weight,
        string Engine,
        int DrivingSpeed,
        int EnginePower,
        FuelType FuelType,
        int FuelConsumption,
        int MaxSpeed,
        int CuttingDiameter,
        int MaxReach,
        TypeChassis TypeChassis,
        float RentalPricePerDay,
        string ImagePath,
        string Description,
        bool IsRepair

        ) : IRequest<ErrorOr<HarvesterResponse>>;
}
