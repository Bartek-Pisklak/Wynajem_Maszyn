﻿using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Features.Rollers.Queries.DTOs;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.Common.Errors;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Features.Rollers.Queries.GetRollers
{
    public class GetRollerQueryHandler : IRequestHandler<GetRollerQuery, ErrorOr<GetRollerDto>>
    {
        private readonly IRollerRepository _rollerRepository;
        private readonly IMachineryRepository _machineryRepository;

        public GetRollerQueryHandler(IRollerRepository rollerRepository,
            IMachineryRepository machineryRepository)
        {
            _rollerRepository = rollerRepository;
            _machineryRepository=machineryRepository;
        }

        public async Task<ErrorOr<GetRollerDto>> Handle(GetRollerQuery request, CancellationToken cancellationToken)
        {
            var roller = await _rollerRepository.GetRoller(request.Id);

            if (roller == null) return Errors.Roller.NotDataToDisplay;

            var machineBusy = new Machinery();
            machineBusy.RollerId = request.Id;

            var dateBusyMachine = await _machineryRepository.GetDateOneMachineryBusy(machineBusy);

            var workRoller = new GetRollerDto
            {
                Id=roller.Id,
                Name = roller.Name,
                ProductionYear = roller.ProductionYear,
                OperatingHours = roller.OperatingHours,
                Weight = roller.Weight,
                Engine = roller.Engine,
                EnginePower = roller.EnginePower,
                DrivingSpeed = roller.DrivingSpeed,
                FuelConsumption = roller.FuelConsumption,
                FuelType = roller.FuelType,
                Gearbox = roller.Gearbox,
                NumberOfDrums = roller.NumberOfDrums,
                RollerType = roller.RollerType,
                DrumWidth = roller.DrumWidth,
                MaxCompactionForce = roller.MaxCompactionForce,
                IsVibratory = roller.IsVibratory,
                KnigeAsfalt = roller.KnigeAsfalt,
                RentalPricePerDay = roller.RentalPricePerDay,
                Description = roller.Description,
                ImagePath = roller.ImagePath.Split(",").ToList(),
                DateBusy = dateBusyMachine,
                IsRepair = roller.IsRepair,
            };

            return workRoller;
        }
    }
}
