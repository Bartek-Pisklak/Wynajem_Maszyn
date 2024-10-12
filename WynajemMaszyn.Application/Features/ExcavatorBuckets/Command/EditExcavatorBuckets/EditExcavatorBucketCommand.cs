using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.ExcavatorBucketAnswer;

namespace WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.EditExcavatorBuckets
{
    public record EditExcavatorBucketCommand
    (
    string Name,
    string BucketType,
    int ProductionYear,
    int BucketCapacity,
    int Weight,
    int Width,
    int PinDiameter,
    int ArmWidth,
    int PinSpacing,
    string Material,
    int MaxLoadCapacity,
    float RentalPricePerDay,
    string CompatibleExcavators,
    string ImagePath,
    string Description


        ) : IRequest<ErrorOr<ExcavatorBucketResponse>>;
}
