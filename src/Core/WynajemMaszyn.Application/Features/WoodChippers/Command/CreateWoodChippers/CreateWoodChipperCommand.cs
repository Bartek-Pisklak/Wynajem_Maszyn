using ErrorOr;
using MediatR;

using WynajemMaszyn.Application.Contracts.WoodChipperAnswer;

namespace WynajemMaszyn.Application.Features.WoodChippers.Command.CreateWoodChippers
{
    public record CreateWoodChipperCommand
    (
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


         int MachineLength,
         int TransportHeight,
         int ChoppingHeight,
         int MachineWidth,

         int FlowMaterial,

         string Description
        ) : IRequest<ErrorOr<WoodChipperResponse>>; 
}
