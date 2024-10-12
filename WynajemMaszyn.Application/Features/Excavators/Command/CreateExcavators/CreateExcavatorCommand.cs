using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.ExcavatorAnswer;

namespace WynajemMaszyn.Application.Features.Excavators.Command.CreateExcavators
{
    public record CreateExcavatorCommand
    (
    int Id,
    int IdUser,
    string Name,
    string Type, // małe, średnie, duże, koparko-ładowarki
    string TypeChassis, // podwozie koła, koparki
    float RentalPricePerDay,
    int ProductionYear,
    int OperatingHours,
    int Weight,
    string Engine, // Model silnika
    int EnginePower,
    int DrivingSpeed,
    int FuelConsumption, // 1/h
    string FuelType, // ropa, benzyna
    string Gearbox, // Skrzynia biegów
    int MaxDiggingDepth, // Maksymalna głębokość kopania
    string Description
                ) : IRequest<ErrorOr<ExcavatorResponse>>;


}
