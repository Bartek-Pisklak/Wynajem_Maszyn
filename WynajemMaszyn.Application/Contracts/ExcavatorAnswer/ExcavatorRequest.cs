namespace WynajemMaszyn.Application.Contracts.ExcavatorAnswer
{
    public record ExcavatorRequest(
        int Id,
        string Name,
        string Type,
        string TypeChassis,
        float RentalPricePerDay,
        int ProductionYear,
        int OperatingHours,
        int Weight,
        string Engine,
        int EnginePower,
        int DrivingSpeed,
        int FuelConsumption,
        string FuelType,
        string Gearbox,
        int MaxDiggingDepth,
        string Description
        );
}

