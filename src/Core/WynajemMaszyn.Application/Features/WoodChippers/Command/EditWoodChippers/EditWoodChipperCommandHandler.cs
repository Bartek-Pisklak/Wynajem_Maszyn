using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.WoodChipperAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;
using Microsoft.AspNetCore.Identity;


namespace WynajemMaszyn.Application.Features.WoodChippers.Command.EditWoodChippers
{
    public class EditWoodChipperCommandHandler : IRequestHandler<EditWoodChipperCommand, ErrorOr<WoodChipperResponse>>
    {
        private readonly IWoodChipperRepository _woodChipperRepository;
        private readonly IMachineryRepository _machineryRepository;
        private readonly ICurrentUserService _currentUserService;

        public EditWoodChipperCommandHandler(IWoodChipperRepository woodChipperRepository,
                                                IMachineryRepository machineryRepository,
                                                ICurrentUserService currentUserService)
        {
            _woodChipperRepository= woodChipperRepository;
            _machineryRepository= machineryRepository;
            _currentUserService=currentUserService;
        }

        public async Task<ErrorOr<WoodChipperResponse>> Handle(EditWoodChipperCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var roles = _currentUserService.Roles;

            if (string.IsNullOrEmpty(userId) || !roles.Contains("Worker"))
            {
                return Errors.ExcavatorBucket.UserDoesNotLogged;
            }


            var woodChipper = new WoodChipper
            {
                UserId = userId,
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
                ImagePath = request.ImagePath,
                Description = request.Description,
                IsRepair = request.IsRepair
            };
            var machinery = new Machinery
            {
                Name= woodChipper.Name,
                WoodChipperId=request.Id
            };

            await _woodChipperRepository.EditWoodChipper(request.Id, woodChipper);
            await _machineryRepository.EditMachinery(machinery);


            return new WoodChipperResponse("Edited Woodchipper");
        }
    }
}
