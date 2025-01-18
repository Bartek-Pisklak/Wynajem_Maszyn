using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using WynajemMaszyn.Application.Contracts.ExcavatorBucketAnswer;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.EditExcavatorBuckets
{
    public record EditExcavatorBucketCommand
    (
    int Id,
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
    string Description,
    bool IsRepair


        ) : IRequest<ErrorOr<ExcavatorBucketResponse>>;
}
