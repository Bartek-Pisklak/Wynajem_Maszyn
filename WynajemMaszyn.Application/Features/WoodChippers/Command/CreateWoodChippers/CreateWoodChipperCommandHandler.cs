using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.WoodChipperAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;

namespace WynajemMaszyn.Application.Features.WoodChippers.Command.CreateWoodChippers
{
    public class CreateWoodChipperCommandHandler : IRequestHandler<CreateWoodChipperCommand, ErrorOr<WoodChipperResponse>>
    {
        private readonly IWoodChipperRepository _woodChipperRepository;
        private readonly IUserContextGetIdService _userContextGetId;
        private readonly IMachineryRepository _machineryRepository;


        public CreateWoodChipperCommandHandler(IWoodChipperRepository woodChipperRepository,
                                                IUserContextGetIdService userContextGetIdService,
                                                IMachineryRepository machineryRepository)
        { 
            _woodChipperRepository= woodChipperRepository;
            _userContextGetId= userContextGetIdService;
            _machineryRepository= machineryRepository;
        }

        public async Task<ErrorOr<WoodChipperResponse>> Handle(CreateWoodChipperCommand request, CancellationToken cancellationToken)
        {
            var userId = 1;//_userContextGetId.GetUserId;

            /*            if (userId is null)
                        {
                            return Errors.WorkTask.UserDoesNotLogged;
                        }*/

            var woodChipper = new WoodChipper
            {
                UserId= userId,
                Name = request.Name,
                RentalPricePerDay = request.RentalPricePerDay,
                ProductionYear = request.ProductionYear,
                OperatingHours = request.OperatingHours,
                Weight = request.Weight,
                Engine = request.Engine,
                EnginePower = request.EnginePower,
                Gearbox = request.Gearbox,
                DrivingSpeed = request.DrivingSpeed,
                FuelConsumption = request.FuelConsumption,
                MachineLength = request.MachineLength,
                TransportHeight = request.TransportHeight,
                ChoppingHeight = request.ChoppingHeight,
                MachineWidth = request.MachineWidth,
                FlowMaterial = request.FlowMaterial,
                Description = request.Description
            };

            var machinery = new Machinery
            {
                Name= woodChipper.Name,
                WoodChipperId=woodChipper.Id
            };

            await _woodChipperRepository.CreateWoodChipper(woodChipper);
            await _machineryRepository.CreateMachinery(machinery);

            return new WoodChipperResponse("added WoodChipper");
        }
    }
}
