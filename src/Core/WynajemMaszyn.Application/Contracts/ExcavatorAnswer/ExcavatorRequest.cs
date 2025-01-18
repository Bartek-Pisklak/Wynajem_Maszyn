using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.Contracts.ExcavatorAnswer
{
    public record ExcavatorRequest(
        
        int Id,
        string Name,
        TypeExcavator TypeExcavator,
        TypeChassis TypeChassis,
        float RentalPricePerDay,
        int ProductionYear,
        int OperatingHours,
        int Weight,
        string Engine,
        int EnginePower,
        int DrivingSpeed,
        int FuelConsumption,
        FuelType FuelType,
        string Gearbox,
        int MaxDiggingDepth,
        string ImagePath,
        string Description,
        bool IsRepair
        );
}

