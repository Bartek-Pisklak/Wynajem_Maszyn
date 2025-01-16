using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using WynajemMaszyn.Application.Contracts.HarversterAnswer;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.Features.Harvesters.Command.CreateHarvesters
{
    public record CreateHarvesterCommand
    (
        HttpContext context,
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
        TypeChassis TypeChassis,
        float RentalPricePerDay,
        string ImagePath,
        string Description

        ) : IRequest<ErrorOr<HarvesterResponse>>;
}
