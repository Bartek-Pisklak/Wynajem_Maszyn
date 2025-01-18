using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.HarversterAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;
using Microsoft.AspNetCore.Identity;


namespace WynajemMaszyn.Application.Features.Harvesters.Command.EditHarvesters
{
    public class EditHarvesterCommandHandler : IRequestHandler<EditHarvesterCommand, ErrorOr<HarvesterResponse>>
    {
        private readonly IHarvesterRepository _harvesterRepository;
        private readonly IMachineryRepository _machineryRepository;
        private readonly ICurrentUserService _currentUserService;

        public EditHarvesterCommandHandler(IHarvesterRepository harvesterRepository,
                                            IMachineryRepository machineryRepository,
                                            ICurrentUserService currentUserService)
        {
            _harvesterRepository = harvesterRepository;
            _machineryRepository = machineryRepository;
            _currentUserService=currentUserService;
        }

        public async Task<ErrorOr<HarvesterResponse>> Handle(EditHarvesterCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var roles = _currentUserService.Roles;

            if (string.IsNullOrEmpty(userId) || !roles.Contains("Worker"))
            {
                return Errors.ExcavatorBucket.UserDoesNotLogged;
            }


            var harvester = new Harvester
            {
                UserId = userId,
                Name = request.Name,
                ProductionYear = request.ProductionYear,
                OperatingHours = request.OperatingHours,
                Weight = request.Weight,
                Engine = request.Engine,
                EnginePower = request.EnginePower,
                DrivingSpeed =request.DrivingSpeed,
                FuelType = request.FuelType,
                FuelConsumption = request.FuelConsumption,
                MaxSpeed = request.MaxSpeed,
                CuttingDiameter = request.CuttingDiameter,
                MaxReach = request.MaxReach,
                TypeChassis = request.TypeChassis,
                RentalPricePerDay = request.RentalPricePerDay,
                ImagePath = request.ImagePath,
                Description = request.Description,
                IsRepair = request.IsRepair
            };

            var machinery = new Machinery
            {
                Name= harvester.Name,
                HarvesterId=request.Id
            };

            await _harvesterRepository.EditHarvester(request.Id, harvester);
            await _machineryRepository.EditMachinery(machinery);

            return new HarvesterResponse("Harvester edit");
        }
    }
}