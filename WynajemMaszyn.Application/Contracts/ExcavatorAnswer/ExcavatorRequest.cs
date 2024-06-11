namespace WynajemMaszyn.Application.Contracts.ExcavatorAnswer
{
    public record ExcavatorRequest(
    int Id,
    string Name,
    DateTime ProductionYear,
    int OperatingHours,
    int Weight,
    int Engine,
    int EnginePower,
    int DrivingSpeed
        );
}

