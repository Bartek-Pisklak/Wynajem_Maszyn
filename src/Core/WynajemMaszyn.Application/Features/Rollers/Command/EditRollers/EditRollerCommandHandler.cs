﻿using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.RollerAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;
using Microsoft.AspNetCore.Identity;

namespace WynajemMaszyn.Application.Features.Rollers.Command.EditRollers
{
    public class EditRollerCommandHandler : IRequestHandler<EditRollerCommand, ErrorOr<RollerResponse>>
    {
        private readonly IRollerRepository _rollerRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMachineryRepository _machineryRepository;

        public EditRollerCommandHandler(IRollerRepository rollerRepository,
                                            UserManager<User> userManager,
                                            IMachineryRepository machineryRepository)
        {
            _rollerRepository = rollerRepository;
            _userManager = userManager;
            _machineryRepository = machineryRepository;
        }

        public async Task<ErrorOr<RollerResponse>> Handle(EditRollerCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(request.context.User);
            var roleUser = await _userManager.GetRolesAsync(user);


            if (user.Id is null && roleUser.Contains("Worker"))
            {
                return Errors.ExcavatorBucket.UserDoesNotLogged;
            }


            var roller = new Roller
            {
                UserId = user.Id,
                Name = request.Name,
                ProductionYear = request.ProductionYear,
                OperatingHours = request.OperatingHours,
                Weight = request.Weight,
                Engine = request.Engine,
                EnginePower = request.EnginePower,
                DrivingSpeed = request.DrivingSpeed,
                FuelConsumption = request.FuelConsumption,
                FuelType = request.FuelType,
                Gearbox = request.Gearbox,
                NumberOfDrums = request.NumberOfDrums,
                RollerType = request.RollerType,
                DrumWidth = request.DrumWidth,
                MaxCompactionForce = request.MaxCompactionForce,
                IsVibratory = request.IsVibratory,
                KnigeAsfalt = request.KnigeAsfalt,
                RentalPricePerDay = request.RentalPricePerDay,
                ImagePath = request.ImagePath,
                Description = request.Description,
                IsRepair = request.IsRepair
            };

            var machinery = new Machinery
            {
                Name= roller.Name,
                RollerId=request.Id
            };

            await _rollerRepository.EditRoller(request.Id, roller);
            await _machineryRepository.EditMachinery(machinery);

            return new RollerResponse("Roller edit");
        }
    }
}
