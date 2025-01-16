using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using WynajemMaszyn.Application.Contracts.ExcavatorBucketAnswer;

namespace WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.CreateExcavatorBuckets
{
    public record CreateExcavatorBucketCommand
    (
    HttpContext context,
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
    //string CompatibleExcavators,
    string ImagePath,
    string Description
                ) : IRequest<ErrorOr<ExcavatorBucketResponse>>;
}
