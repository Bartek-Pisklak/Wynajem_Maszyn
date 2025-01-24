﻿using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Features.Rollers.Queries.DTOs;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;

using WynajemMaszyn.Application.Common.Errors;

namespace WynajemMaszyn.Application.Features.Rollers.Queries.GetAllRollers
{
    public class GetAllRollerQueryHandler : IRequestHandler<GetAllRollerQuery, ErrorOr<List<GetAllRollerDto>>>
    {
        private readonly IRollerRepository _rollerRepository;
        public GetAllRollerQueryHandler(IRollerRepository rollerRepository)
        {
        _rollerRepository = rollerRepository;
        }

        public async Task<ErrorOr<List<GetAllRollerDto>>> Handle(GetAllRollerQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Roller> rollers;

            rollers = await _rollerRepository.GetAllRoller();


            if (!rollers.Any()) return Errors.Roller.NotDataToDisplay;

            List<GetAllRollerDto> workRollers = rollers.Select(x => new GetAllRollerDto
            {
                Id=x.Id,
                Name = x.Name,
                ProductionYear = x.ProductionYear,
                OperatingHours = x.OperatingHours,
                Weight = x.Weight,
                Engine = x.Engine,
                EnginePower = x.EnginePower,
                DrivingSpeed = x.DrivingSpeed,
                FuelConsumption = x.FuelConsumption,
                FuelType = x.FuelType,
                Gearbox = x.Gearbox,
                NumberOfDrums = x.NumberOfDrums,
                RollerType = x.RollerType,
                DrumWidth = x.DrumWidth,
                MaxCompactionForce = x.MaxCompactionForce,
                IsVibratory = x.IsVibratory,
                KnigeAsfalt = x.KnigeAsfalt,
                RentalPricePerDay = x.RentalPricePerDay,
                Description = x.Description

            }).ToList();

            return workRollers;
        }
    }
}
