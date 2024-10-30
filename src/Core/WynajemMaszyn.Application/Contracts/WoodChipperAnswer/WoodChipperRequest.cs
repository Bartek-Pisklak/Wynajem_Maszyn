using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WynajemMaszyn.Application.Contracts.WoodChipperAnswer
{
    public record WoodChipperRequest
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

     string Description 
        );
}
