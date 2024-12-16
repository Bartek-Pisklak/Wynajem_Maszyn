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

            excavatorBucket = await _excavatorBucketRepository.GetExcavatorBucket(request.Id);

            if (excavatorBucket == null) return Errors.ExcavatorBucket.NotDataToDisplay;

            GetExcavatorBucketDto workExcavatorBucket = (new GetExcavatorBucketDto
            {
                Name = excavatorBucket.Name,
                BucketType = excavatorBucket.BucketType,
                ProductionYear = excavatorBucket.ProductionYear,
                BucketCapacity = excavatorBucket.BucketCapacity,
                Weight = excavatorBucket.Weight,

                Width = excavatorBucket.Width,
                PinDiameter = excavatorBucket.PinDiameter,
                ArmWidth = excavatorBucket.ArmWidth,
                PinSpacing = excavatorBucket.PinSpacing,

                Material = excavatorBucket.Material,
                MaxLoadCapacity = excavatorBucket.MaxLoadCapacity,
                RentalPricePerDay = excavatorBucket.RentalPricePerDay,
                CompatibleExcavators = excavatorBucket.CompatibleExcavators,

                ImagePath = excavatorBucket.ImagePath,
                Description = excavatorBucket.Description,
                IsRepair = excavatorBucket.IsRepair
            });

            return workExcavatorBucket;
        }
    }
}
