using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.ExcavatorBucketAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;

namespace WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.CreateExcavatorBuckets
{
    public class CreateExcavatorBucketCommandHandler : IRequestHandler<CreateExcavatorBucketCommand, ErrorOr<ExcavatorBucketResponse>>
    {
        private readonly IExcavatorBucketRepository _excavatorBucketRepository;
        private readonly IMachineryRepository _machineryRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreateExcavatorBucketCommandHandler(IExcavatorBucketRepository excavatorBucketRepository,
            IMachineryRepository machineryRepository,
            ICurrentUserService currentUserService)
        {
            _excavatorBucketRepository=excavatorBucketRepository;
            _machineryRepository=machineryRepository;
            _currentUserService=currentUserService;
        }

        public async Task<ErrorOr<ExcavatorBucketResponse>> Handle(CreateExcavatorBucketCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var roles = _currentUserService.Roles;

            if (string.IsNullOrEmpty(userId) || !roles.Contains("Worker"))
            {
                return Errors.ExcavatorBucket.UserDoesNotLogged;
            }

            var excavatorBucket = new ExcavatorBucket
            {
                UserId = userId,
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


            var idNewMahine = await _excavatorBucketRepository.CreateExcavatorBucket(excavatorBucket);

            var machine = new Machinery
            {
                Name= excavatorBucket.Name,
                ExcavatorBucketId = idNewMahine
            };

            await _machineryRepository.CreateMachinery(machine);

            return new ExcavatorBucketResponse("ExcavatorBucket added");

        }
    }

}
