﻿using WynajemMaszyn.Domain.Enums;

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
        FuelType FuelType,
        string Gearbox,
        int NumberOfDrums,
        RollerType RollerType,
        int DrumWidth,
        int MaxCompactionForce,
        bool IsVibratory,
        bool KnigeAsfalt,
        float RentalPricePerDay,
        string ImagePath,
        string Description,
        bool IsRepair
    );
}