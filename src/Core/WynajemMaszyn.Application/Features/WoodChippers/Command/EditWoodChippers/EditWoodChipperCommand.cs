using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Application.Contracts.WoodChipperAnswer;

namespace WynajemMaszyn.Application.Features.WoodChippers.Command.EditWoodChippers
{
    public record EditWoodChipperCommand
    (
         int Id,
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

         string ImagePath,
         string Description
        ) : IRequest<ErrorOr<WoodChipperResponse>>;
}
