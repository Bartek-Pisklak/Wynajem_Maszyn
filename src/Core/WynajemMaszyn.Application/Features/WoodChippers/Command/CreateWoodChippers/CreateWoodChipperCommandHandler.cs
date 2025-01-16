using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.WoodChipperAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;
using Microsoft.AspNetCore.Identity;

namespace WynajemMaszyn.Application.Features.WoodChippers.Command.CreateWoodChippers
{
    public class CreateWoodChipperCommandHandler : IRequestHandler<CreateWoodChipperCommand, ErrorOr<WoodChipperResponse>>
    {
        private readonly IWoodChipperRepository _woodChipperRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMachineryRepository _machineryRepository;


        public CreateWoodChipperCommandHandler(IWoodChipperRepository woodChipperRepository,
                                                UserManager<User> userManager,
                                                IMachineryRepository machineryRepository)
        { 
            _woodChipperRepository= woodChipperRepository;
            _userManager = userManager;
            _machineryRepository= machineryRepository;
        }

        public async Task<ErrorOr<WoodChipperResponse>> Handle(CreateWoodChipperCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(request.context.User);
            var roleUser = await _userManager.GetRolesAsync(user);


            if (user.Id is null && roleUser.Contains("Worker"))
            {
                return Errors.ExcavatorBucket.UserDoesNotLogged;
            }

            var woodChipper = new WoodChipper
            {
                UserId= user.Id,
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
                Description = request.Description
            };



            var idNewMahine = await _woodChipperRepository.CreateWoodChipper(woodChipper);

            var machinery = new Machinery
            {
                Name= woodChipper.Name,
                WoodChipperId=idNewMahine
            };
            await _machineryRepository.CreateMachinery(machinery);

            return new WoodChipperResponse("added WoodChipper");
        }
    }
}
