using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Features.ExcavatorBucket.Queries.DTOs;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.Common.Errors;
using WynajemMaszyn.Domain.Entities;


namespace WynajemMaszyn.Application.Features.ExcavatorBucket.Queries.GetExcavatorBucket
{
    public class GetExcavatorBucketQueryHandler : IRequestHandler<GetExcavatorBucketQuery, ErrorOr<GetExcavatorBucketDto>>
    {
        private readonly IExcavatorRepository _excavatorBucketRepository;

        public GetExcavatorBucketQueryHandler(IExcavatorRepository excavatorRepository)
        {
            _excavatorBucketRepository=excavatorRepository;
        }

        public Task<ErrorOr<GetExcavatorBucketDto>> Handle(GetExcavatorBucketQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ExcavatorBucket> excavatorBucket;

            excavatorBucket = await _excavatorBucketRepository.GetExcavatorBucket();

            if (!excavatorBucket.Any()) return Errors.ExcavatorBucket.NotDataToDisplay;

            List<GetExcavatorBucketDto> workExcavatorBucket = excavatorBucket.Select(x => new GetExcavatorBucketDto
            {
                Id=x.Id,
                Name=x.Name,
                ProductionYear=x.ProductionYear,
                OperatingHours=x.OperatingHours,
                Weight= x.Weight,
                Engine = x.Engine,
                EnginePower = x.EnginePower,
                DrivingSpeed = x.DrivingSpeed
            }).ToList();

            return workExcavatorBucket;

        }
    }
}
