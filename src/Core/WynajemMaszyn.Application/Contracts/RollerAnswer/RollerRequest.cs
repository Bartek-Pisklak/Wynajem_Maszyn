using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WynajemMaszyn.Application.Contracts.RollerAnswer
{
    public record RollerRequest
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
        string Description
    );
}
