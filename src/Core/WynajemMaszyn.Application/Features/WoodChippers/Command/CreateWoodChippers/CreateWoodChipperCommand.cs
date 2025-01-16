using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using WynajemMaszyn.Application.Contracts.WoodChipperAnswer;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.Features.WoodChippers.Command.CreateWoodChippers
{
    public record CreateWoodChipperCommand
    (
         HttpContext context,
         string Name,

         float RentalPricePerDay,
         int ProductionYear,
         int OperatingHours,
         int Weight,

         string Engine,
         int EnginePower,
         string Gearbox,
         int DrivingSpeed,
         int FuelConsumption,
         FuelType FuelType,

         int MachineLength,
         int TransportHeight,
         int ChoppingHeight,
         int MachineWidth,

         int FlowMaterial,
         string ImagePath,
         string Description
        ) : IRequest<ErrorOr<WoodChipperResponse>>; 
}
