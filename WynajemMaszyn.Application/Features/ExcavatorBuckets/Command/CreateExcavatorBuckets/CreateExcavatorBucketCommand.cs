using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.ExcavatorBucketAnswer;

namespace WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.CreateExcavatorBuckets
{
    public record CreateExcavatorBucketCommand
    (
    int Id,
    int IdUser,
    string Name,
    DateTime ProductionYear,
    int Weight,
    string Description

                ) : IRequest<ErrorOr<ExcavatorBucketResponse>>;
}
