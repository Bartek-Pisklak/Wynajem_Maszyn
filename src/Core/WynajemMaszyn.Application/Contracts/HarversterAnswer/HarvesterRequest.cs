using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.Contracts.HarversterAnswer
{
    public record HarvesterRequest
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
    );
}
