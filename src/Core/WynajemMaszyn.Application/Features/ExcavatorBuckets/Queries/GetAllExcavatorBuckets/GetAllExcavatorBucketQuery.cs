using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.DTOs;

namespace WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.GetAllExcavatorBuckets
{
    public record GetAllExcavatorBucketQuery(
        ) : IRequest<ErrorOr<List<GetExcavatorBucketDto>>>;
}
