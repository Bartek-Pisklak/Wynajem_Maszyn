using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.ExcavatorBucketAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;
using Microsoft.AspNetCore.Identity;

namespace WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.EditExcavatorBuckets
{
    public class EditExcavatorBucketCommandHandler : IRequestHandler<EditExcavatorBucketCommand, ErrorOr<ExcavatorBucketResponse>>
    {
        private readonly IExcavatorBucketRepository _excavatorBucketRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMachineryRepository _machineryRepository;

        public EditExcavatorBucketCommandHandler(IExcavatorBucketRepository excavatorBucketRepository, 
            UserManager<User> userManager,
            IMachineryRepository machineryRepository)
        {
            _excavatorBucketRepository=excavatorBucketRepository;
            _userManager=userManager;
            _machineryRepository=machineryRepository;
        }

        public async Task<ErrorOr<ExcavatorBucketResponse>> Handle(EditExcavatorBucketCommand request, CancellationToken cancellationToken)
        {

            var user = await _userManager.GetUserAsync(request.context.User);
            var roleUser = await _userManager.GetRolesAsync(user);


            if (user.Id is null && roleUser.Contains("Worker"))
            {
                return Errors.ExcavatorBucket.UserDoesNotLogged;
            }

            var excavatorBucket = new ExcavatorBucket
            {
                UserId = user.Id,
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
                Description = request.Description,
                IsRepair = request.IsRepair,
            };

           
            var machine = new Machinery
            {
                Name = excavatorBucket.Name,
                ExcavatorBucketId = request.Id
            };

            await _excavatorBucketRepository.EditExcavatorBucket(request.Id,excavatorBucket);
            await _machineryRepository.EditMachinery(machine);


            return new ExcavatorBucketResponse("Edit Excavator bucket");
        }
    }
}
