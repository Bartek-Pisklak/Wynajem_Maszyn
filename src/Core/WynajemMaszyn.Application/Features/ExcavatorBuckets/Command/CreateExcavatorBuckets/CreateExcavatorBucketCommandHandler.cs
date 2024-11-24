using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.ExcavatorBucketAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;
using WynajemMaszyn.Application.Common.Interfaces.Authentication;

namespace WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.CreateExcavatorBuckets
{
    public class CreateExcavatorBucketCommandHandler : IRequestHandler<CreateExcavatorBucketCommand, ErrorOr<ExcavatorBucketResponse>>
    {
        private readonly IExcavatorBucketRepository _excavatorBucketRepository;
        private readonly ICurrentUserService _userContextGetId;
        private readonly IMachineryRepository _machineryRepository;

        public CreateExcavatorBucketCommandHandler(IExcavatorBucketRepository excavatorBucketRepository,
            ICurrentUserService userContextGetId,
            IMachineryRepository machineryRepository)
        {
            _excavatorBucketRepository=excavatorBucketRepository;
            _userContextGetId=userContextGetId;
            _machineryRepository=machineryRepository;
        }

        public async Task<ErrorOr<ExcavatorBucketResponse>> Handle(CreateExcavatorBucketCommand request, CancellationToken cancellationToken)
        {
            var userId = _userContextGetId.GetUserId;
            //var userPermisionId = _userContextGetId.;
            if (userId is null)// && permission == "Worker")//&& )
            {
                return Errors.ExcavatorBucket.UserDoesNotLogged;
            }

            var excavatorBucket = new ExcavatorBucket
            {
                UserId = (int)userId,
                Name = request.Name,
                BucketType = request.BucketType,
                ProductionYear = request.ProductionYear,
                BucketCapacity = request.BucketCapacity,
                Weight = request.Weight,

                Width = request.Width,
                PinDiameter = request.PinDiameter,
                ArmWidth = request.ArmWidth,
                PinSpacing = request.PinSpacing,

                Material = request.Material,
                MaxLoadCapacity = request.MaxLoadCapacity,
                RentalPricePerDay = request.RentalPricePerDay,
                //CompatibleExcavators = request.CompatibleExcavators,

                ImagePath = request.ImagePath,
                Description = request.Description
            };

            var machine = new Machinery
            {
                Name= excavatorBucket.Name,
                ExcavatorBucketId = excavatorBucket.Id 
            };

            await _excavatorBucketRepository.CreateExcavatorBucket(excavatorBucket);
            await _machineryRepository.CreateMachinery(machine);
            return new ExcavatorBucketResponse("ExcavatorBucket added");

        }
    }

}
