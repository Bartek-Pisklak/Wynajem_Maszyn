using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.ExcavatorBucketAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.EditExcavatorBuckets
{
    public class EditExcavatorBucketCommandHandler : IRequestHandler<EditExcavatorBucketCommand, ErrorOr<ExcavatorBucketResponse>>
    {
        private readonly IExcavatorBucketRepository _excavatorBucketRepository;
        private readonly IUserContextGetIdService _userContextGetId;
        private readonly IMachineryRepository _machineryRepository;

        public EditExcavatorBucketCommandHandler(IExcavatorBucketRepository excavatorBucketRepository, 
            IUserContextGetIdService userContextGetId,
            IMachineryRepository machineryRepository)
        {
            _excavatorBucketRepository=excavatorBucketRepository;
            _userContextGetId=userContextGetId;
            _machineryRepository=machineryRepository;
        }

        public async Task<ErrorOr<ExcavatorBucketResponse>> Handle(EditExcavatorBucketCommand request, CancellationToken cancellationToken)
        {

            var userId = 1;//_userContextGetId.GetUserId;

            /*            if (userId is null)
                        {
                            return Errors.WorkTask.UserDoesNotLogged;
                        }*/

            var excavatorBucket = new ExcavatorBucket
            {
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
                CompatibleExcavators = request.CompatibleExcavators,

                ImagePath = request.ImagePath,
                Description = request.Description
            };

           
            var machine = new Machinery
            {
                Name = excavatorBucket.Name
            };

            await _excavatorBucketRepository.CreateExcavatorBucket(excavatorBucket);
            await _machineryRepository.EditMachinery(machine);


            return new ExcavatorBucketResponse("Edit Excavator bucket");
        }
    }
}
