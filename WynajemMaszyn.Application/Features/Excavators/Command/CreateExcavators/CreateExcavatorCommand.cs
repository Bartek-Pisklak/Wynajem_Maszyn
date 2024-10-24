using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.ExcavatorAnswer;

namespace WynajemMaszyn.Application.Features.Excavators.Command.CreateExcavators
{
    public record CreateExcavatorCommand
    (
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
    string ImagePath,
    string Description
                ) : IRequest<ErrorOr<ExcavatorResponse>>;


}
