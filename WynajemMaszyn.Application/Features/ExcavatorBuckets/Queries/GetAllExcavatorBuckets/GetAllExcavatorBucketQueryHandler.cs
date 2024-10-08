using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.Common.Errors;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.DTOs;

namespace WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.GetAllExcavatorBuckets
{
    public class GetAllExcavatorBucketQueryHandler : IRequestHandler<GetAllExcavatorBucketQuery, ErrorOr<List<GetExcavatorBucketDto>>>
    {

        private readonly IExcavatorBucketRepository _excavatorBucketRepository;

        public GetAllExcavatorBucketQueryHandler(IExcavatorBucketRepository excavatorBucketRepository)
        {
            _excavatorBucketRepository = excavatorBucketRepository;
        }

        public async Task<ErrorOr<List<GetExcavatorBucketDto>>> Handle(GetAllExcavatorBucketQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ExcavatorBucket> excavatorBucket;

            excavatorBucket = await _excavatorBucketRepository.GetAllExcavatorBucket();

            if (!excavatorBucket.Any()) return Errors.ExcavatorBucket.NotDataToDisplay;

            List<GetExcavatorBucketDto> workExcavatorBucket = excavatorBucket.Select(x => new GetExcavatorBucketDto
            {
                Id = x.Id,
                Name = x.Name,
                ProductionYear = x.ProductionYear,
                Weight = x.Weight,
            }).ToList();

            return workExcavatorBucket;
        }
    }
}
