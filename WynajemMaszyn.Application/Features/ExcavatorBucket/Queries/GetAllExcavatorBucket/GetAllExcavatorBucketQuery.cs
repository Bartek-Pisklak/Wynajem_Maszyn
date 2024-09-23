using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Features.ExcavatorBucket.Queries.DTOs;


namespace WynajemMaszyn.Application.Features.ExcavatorBucket.Queries.GetAllExcavatorBucket
{
    public record GetAllExcavatorBucketQuery
    () : IRequest<ErrorOr<List<GetExcavatorBucketDto>>>;
}
