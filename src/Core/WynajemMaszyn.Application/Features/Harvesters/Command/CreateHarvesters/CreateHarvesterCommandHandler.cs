using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.HarversterAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;
using Microsoft.AspNetCore.Identity;

namespace WynajemMaszyn.Application.Features.Harvesters.Command.CreateHarvesters
{
    public class CreateHarvesterCommandHandler : IRequestHandler<CreateHarvesterCommand, ErrorOr<HarvesterResponse>>
    {

        private readonly IHarvesterRepository _harvesterRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMachineryRepository _machineryRepository;


        public CreateHarvesterCommandHandler(IHarvesterRepository harvesterRepository,
                                            UserManager<User> userManager,
                                            IMachineryRepository machineryRepository)
        {
            _harvesterRepository = harvesterRepository;
            _userManager = userManager;
            _machineryRepository = machineryRepository;
        }

        public async Task<ErrorOr<HarvesterResponse>> Handle(CreateHarvesterCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(request.context.User);
            var roleUser = await _userManager.GetRolesAsync(user);


            if (user.Id is null && roleUser.Contains("Worker"))
            {
                return Errors.ExcavatorBucket.UserDoesNotLogged;
            }

            var harvester = new Harvester
            {
                UserId = user.Id,
                Name = request.Name,
                ProductionYear = request.ProductionYear,
                OperatingHours = request.OperatingHours,
                Weight = request.Weight,
                Engine = request.Engine,
                DrivingSpeed = request.DrivingSpeed,
                EnginePower = request.EnginePower,
                FuelType = request.FuelType,
                FuelConsumption = request.FuelConsumption,
                MaxSpeed = request.MaxSpeed,
                CuttingDiameter = request.CuttingDiameter,
                MaxReach = request.MaxReach,
                TypeChassis = request.TypeChassis,
                RentalPricePerDay = request.RentalPricePerDay,
                ImagePath = request.ImagePath,
                Description = request.Description
            };





            var idNewMahine = await _harvesterRepository.CreateHarvester(harvester);
            var machinery = new Machinery
            {
                Name= harvester.Name,
                HarvesterId=idNewMahine
            };
            await _machineryRepository.CreateMachinery(machinery);

            return new HarvesterResponse("Harvester added");
        }
    }
}

