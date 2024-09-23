using ErrorOr;
using MediatR;

using WynajemMaszyn.Application.Features.ExcavatorBucket.Queries.DTOs;


namespace WynajemMaszyn.Application.Features.ExcavatorBucket.Queries.GetExcavatorBucket
{
    public record GetExcavatorBucketQuery
    () : IRequest<ErrorOr<List<GetExcavatorBucketDto>>>;
}
