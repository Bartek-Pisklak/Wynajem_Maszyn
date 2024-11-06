using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.WoodChipperAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;


namespace WynajemMaszyn.Application.Features.WoodChippers.Command.EditWoodChippers
{
    public class EditWoodChipperCommandHandler : IRequestHandler<EditWoodChipperCommand, ErrorOr<WoodChipperResponse>>
    {
        private readonly IWoodChipperRepository _woodChipperRepository;
        private readonly IUserContextGetIdService _userContextGetId;
        private readonly IMachineryRepository _machineryRepository;

        public EditWoodChipperCommandHandler(IWoodChipperRepository woodChipperRepository,
                                                IUserContextGetIdService userContextGetIdService,
                                                IMachineryRepository machineryRepository)
        {
            _woodChipperRepository= woodChipperRepository;
            _userContextGetId= userContextGetIdService;
            _machineryRepository= machineryRepository;
        }

        public async Task<ErrorOr<WoodChipperResponse>> Handle(EditWoodChipperCommand request, CancellationToken cancellationToken)
        {
            var userId = _userContextGetId.GetUserId;

            if (userId is null)
            {
                return Errors.WoodChipper.UserDoesNotLogged;
            }



            var id = request.Id;
            var woodChipper = new WoodChipper
            {
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
                WoodChipperId=id
            };

            await _woodChipperRepository.EditWoodChipper(id,woodChipper);
            await _machineryRepository.EditMachinery(machinery);


            return new WoodChipperResponse("Edited Woodchipper");
        }
    }
}
