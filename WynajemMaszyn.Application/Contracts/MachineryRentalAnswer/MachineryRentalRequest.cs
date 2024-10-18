using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WynajemMaszyn.Application.Contracts.MachineryRentalAnswer
{
    public record MachineryRentalRequest
    (
        int Id,
        string Name,
        int ProductionYear,
        int OperatingHours,
        int Weight,
        int EnginePower,
        string FuelType,
        int FuelConsumption,
        int MaxSpeed,
        int CuttingDiameter,
        int MaxReach,
        string WheelType,
        float RentalPricePerDay,
        string ImagePath,
        string Description
    );
}
