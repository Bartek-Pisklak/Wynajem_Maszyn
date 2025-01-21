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
        private readonly IMachineryRepository _machineryRepository;

        public GetExcavatorBucketQueryHandler(IExcavatorBucketRepository excavatorRepository
            , IMachineryRepository machineryRepository)
        {
            _excavatorBucketRepository = excavatorRepository;
            _machineryRepository=machineryRepository;
        }

        public async Task<ErrorOr<GetExcavatorBucketDto>> Handle(GetExcavatorBucketQuery request, CancellationToken cancellationToken)
        {
            ExcavatorBucket excavatorBucket;

            excavatorBucket = await _excavatorBucketRepository.GetExcavatorBucket(request.Id);

            if (excavatorBucket == null) return Errors.ExcavatorBucket.NotDataToDisplay;

            var machineBusy = new Machinery();
            machineBusy.ExcavatorBucketId = request.Id;

            var dateBusyMachine = await _machineryRepository.GetDateOneMachineryBusy(machineBusy);

            GetExcavatorBucketDto workExcavatorBucket = (new GetExcavatorBucketDto
            {
                Id = excavatorBucket.Id,
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
                //CompatibleExcavators = excavatorBucket.CompatibleExcavators,
                ImagePath = excavatorBucket.ImagePath.Split(",").ToList(),
                Description = excavatorBucket.Description,
                DateBusy = dateBusyMachine,
                IsRepair = excavatorBucket.IsRepair
            });

            return workExcavatorBucket;
        }
    }
}
