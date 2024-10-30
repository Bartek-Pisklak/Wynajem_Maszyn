using ErrorOr;
using MediatR;

using WynajemMaszyn.Application.Contracts.ExcavatorBucketAnswer;

namespace WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.DeleteExcavatorBuckets
{
    public record DeleteExcavatorBucketCommand
    (
        int Id
    ) : IRequest<ErrorOr<ExcavatorBucketResponse>>;
}
