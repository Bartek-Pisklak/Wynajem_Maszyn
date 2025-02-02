﻿using MediatR;
using ErrorOr;
using WynajemMaszyn.Application.Features.Harvesters.Queries.DTOs;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.Common.Errors;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Features.Harvesters.Queries.GetHarvesters
{
    public class GetHarvesterQueryHandler : IRequestHandler<GetHarvesterQuery, ErrorOr<GetHarvesterDto>>
    {
        private readonly IHarvesterRepository _harvesterRepository;
        private readonly IMachineryRepository _machineryRepository;

        public GetHarvesterQueryHandler(IHarvesterRepository harvesterRepository,
            IMachineryRepository machineryRepository)
        {
            _harvesterRepository = harvesterRepository;
            _machineryRepository=machineryRepository;
        }

        public async Task<ErrorOr<GetHarvesterDto>> Handle(GetHarvesterQuery request, CancellationToken cancellationToken)
        {
            var harvester = await _harvesterRepository.GetHarvester(request.Id);


            if (harvester == null) return Errors.Harvester.NotDataToDisplay;
            var machineBusy = new Machinery();
            machineBusy.HarvesterId = request.Id;

            var dateBusyMachine = await _machineryRepository.GetDateOneMachineryBusy(machineBusy);

            var workHarvester = new GetHarvesterDto
            {
                Id=harvester.Id,
                Name = harvester.Name,
                ProductionYear = harvester.ProductionYear,
                OperatingHours = harvester.OperatingHours,
                Weight = harvester.Weight,
                Engine = harvester.Engine,
                DrivingSpeed = harvester.DrivingSpeed,
                EnginePower = harvester.EnginePower,
                FuelType = harvester.FuelType,
                FuelConsumption = harvester.FuelConsumption,
                MaxSpeed = harvester.MaxSpeed,
                CuttingDiameter = harvester.CuttingDiameter,
                MaxReach = harvester.MaxReach,
                TypeChassis = harvester.TypeChassis,
                RentalPricePerDay = harvester.RentalPricePerDay,
                ImagePath = harvester.ImagePath.Split(",").ToList(),
                Description = harvester.Description,
                DateBusy = dateBusyMachine,
                IsRepair = harvester.IsRepair,
            };

            return workHarvester;
        }
    }
}
