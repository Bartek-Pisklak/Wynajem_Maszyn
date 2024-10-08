using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.Common.Errors;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.DTOs;


namespace WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.GetExcavatorBuckets
{
    public class GetExcavatorBucketQueryHandler : IRequestHandler<GetExcavatorBucketQuery, ErrorOr<GetExcavatorBucketDto>>
    {
        private readonly IExcavatorBucketRepository _excavatorBucketRepository;

        public GetExcavatorBucketQueryHandler(IExcavatorBucketRepository excavatorRepository)
        {
            _excavatorBucketRepository = excavatorRepository;
        }

        public async Task<ErrorOr<GetExcavatorBucketDto>> Handle(GetExcavatorBucketQuery request, CancellationToken cancellationToken)
        {
            ExcavatorBucket excavatorBucket;

            excavatorBucket = await _excavatorBucketRepository.GetExcavatorBucket(1);

            if (excavatorBucket == null) return Errors.ExcavatorBucket.NotDataToDisplay;

            GetExcavatorBucketDto workExcavatorBucket = (new GetExcavatorBucketDto
            {
                Id = excavatorBucket.Id,
                Name = excavatorBucket.Name,
                ProductionYear = excavatorBucket.ProductionYear,
                Weight = excavatorBucket.Weight,
            });

            return workExcavatorBucket;
        }
    }
}
