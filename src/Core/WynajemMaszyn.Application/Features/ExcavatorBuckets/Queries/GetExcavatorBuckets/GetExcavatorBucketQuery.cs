using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.DTOs;


namespace WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.GetExcavatorBuckets
{
    public record GetExcavatorBucketQuery(
        int Id
        ) : IRequest<ErrorOr<GetExcavatorBucketDto>>;
}
