using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.Common.Errors;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.DTOs;

namespace WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.GetAllExcavatorBuckets
{
    public class GetAllExcavatorBucketQueryHandler : IRequestHandler<GetAllExcavatorBucketQuery, ErrorOr<List<GetAllExcavatorBucketDto>>>
    {

        private readonly IExcavatorBucketRepository _excavatorBucketRepository;

        public GetAllExcavatorBucketQueryHandler(IExcavatorBucketRepository excavatorBucketRepository)
        {
            _excavatorBucketRepository = excavatorBucketRepository;
        }


        public async Task<ErrorOr<List<GetAllExcavatorBucketDto>>> Handle(GetAllExcavatorBucketQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ExcavatorBucket> excavatorBucket;

            excavatorBucket = await _excavatorBucketRepository.GetAllExcavatorBucket();

            if (!excavatorBucket.Any()) return Errors.ExcavatorBucket.NotDataToDisplay;

            List<GetAllExcavatorBucketDto> workExcavatorBucket = excavatorBucket.Select(x => new GetAllExcavatorBucketDto
            {
                Id = x.Id,
                Name = x.Name,
                BucketType = x.BucketType,
                Weight = x.Weight,
                ProductionYear = x.ProductionYear,
                RentalPricePerDay = x.RentalPricePerDay,
                ImagePath = x.ImagePath,
                IsRepair = x.IsRepair,
            }).ToList();

            return workExcavatorBucket;
        }
    }
}
