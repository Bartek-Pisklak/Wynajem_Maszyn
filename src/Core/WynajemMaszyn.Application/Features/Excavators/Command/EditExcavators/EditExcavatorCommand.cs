using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using WynajemMaszyn.Application.Contracts.ExcavatorAnswer;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.Features.Excavators.Command.EditExcavators
{
    public record EditExcavatorCommand
    (
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
                ) : IRequest<ErrorOr<ExcavatorResponse>>;
}
