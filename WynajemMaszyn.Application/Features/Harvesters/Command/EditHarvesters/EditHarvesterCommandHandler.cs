using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.HarversterAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Features.Harvesters.Command.EditHarvesters
{
    public class EditHarvesterCommandHandler : IRequestHandler<EditHarvesterCommand, ErrorOr<HarvesterResponse>>
    {
        private readonly IHarvesterRepository _harvesterRepository;
        private readonly IUserContextGetIdService _userContextGetId;
        private readonly IMachineryRepository _machineryRepository;

        public EditHarvesterCommandHandler(IHarvesterRepository harvesterRepository,
                                            IUserContextGetIdService userContextGetId,
                                            IMachineryRepository machineryRepository)
        {
            _harvesterRepository = harvesterRepository;
            _userContextGetId = userContextGetId;
            _machineryRepository = machineryRepository;
        }

        public async Task<ErrorOr<HarvesterResponse>> Handle(EditHarvesterCommand request, CancellationToken cancellationToken)
        {
            var userId = 1;//_userContextGetId.GetUserId;

            /*            if (userId is null)
                        {
                            return Errors.WorkTask.UserDoesNotLogged;
                        }*/


            var harvester = new Harvester
            {
                Name = request.Name,
                ProductionYear = request.ProductionYear,
                OperatingHours = request.OperatingHours,
                Weight = request.Weight,
                EnginePower = request.EnginePower,
                FuelType = request.FuelType,
                FuelConsumption = request.FuelConsumption,
                MaxSpeed = request.MaxSpeed,
                CuttingDiameter = request.CuttingDiameter,
                MaxReach = request.MaxReach,
                WheelType = request.WheelType,
                RentalPricePerDay = request.RentalPricePerDay,
                ImagePath = request.ImagePath,
                Description = request.Description
            };

            var machinery = new Machinery
            {
                Name= harvester.Name,
                IdHarvester=harvester.Id
            };

            await _harvesterRepository.EditHarvester(request.Id, harvester);
            await _machineryRepository.EditMachinery(machinery);

            return new HarvesterResponse("Harvester edit");
        }
    }
}