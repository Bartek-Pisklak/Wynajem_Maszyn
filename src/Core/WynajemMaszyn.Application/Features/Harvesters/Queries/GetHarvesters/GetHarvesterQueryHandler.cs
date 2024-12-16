using MediatR;
using ErrorOr;
using WynajemMaszyn.Application.Features.Harvesters.Queries.DTOs;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.Common.Errors;

namespace WynajemMaszyn.Application.Features.Harvesters.Queries.GetHarvesters
{
    public class GetHarvesterQueryHandler : IRequestHandler<GetHarvesterQuery, ErrorOr<GetHarvesterDto>>
    {
        private readonly IHarvesterRepository _harvesterRepository;

        public GetHarvesterQueryHandler(IHarvesterRepository harvesterRepository)
        {
            _harvesterRepository = harvesterRepository;
        }

        public async Task<ErrorOr<GetHarvesterDto>> Handle(GetHarvesterQuery request, CancellationToken cancellationToken)
        {
            var harvester = await _harvesterRepository.GetHarvester(request.Id);


            if (harvester == null) return Errors.Harvester.NotDataToDisplay;


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
                WheelType = harvester.WheelType,
                RentalPricePerDay = harvester.RentalPricePerDay,
                ImagePath = harvester.ImagePath,
                Description = harvester.Description
            };

            return workHarvester;
        }
    }
}
