using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Features.WoodChippers.Queries.DTOs;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;

namespace WynajemMaszyn.Application.Features.WoodChippers.Queries.GetAllWoodChippers
{
    public class GetAllWoodChipperQueryHandler : IRequestHandler<GetAllWoodChipperQuery, ErrorOr<List<GetAllWoodChipperDto>>>
    {
        private readonly IWoodChipperRepository _woodChipperRepository;

        public GetAllWoodChipperQueryHandler(IWoodChipperRepository woodChipperRepository)
        {
            _woodChipperRepository = woodChipperRepository;
        }

        public async Task<ErrorOr<List<GetAllWoodChipperDto>>> Handle(GetAllWoodChipperQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<WoodChipper> woodChippers;

            woodChippers = await _woodChipperRepository.GetAllWoodChipper();


            if (!woodChippers.Any()) return Errors.WoodChipper.NotDataToDisplay;

            List<GetAllWoodChipperDto> workWoodChippers = woodChippers.Select(woodChipper => new GetAllWoodChipperDto
            {
                Name = woodChipper.Name,
                RentalPricePerDay = woodChipper.RentalPricePerDay,
                ProductionYear = woodChipper.ProductionYear,
                OperatingHours = woodChipper.OperatingHours,
                Weight = woodChipper.Weight,
                Engine = woodChipper.Engine,
                EnginePower = woodChipper.EnginePower,
                Gearbox = woodChipper.Gearbox,
                DrivingSpeed = woodChipper.DrivingSpeed,
                FuelConsumption = woodChipper.FuelConsumption,
                MachineLength = woodChipper.MachineLength,
                TransportHeight = woodChipper.TransportHeight,
                ChoppingHeight = woodChipper.ChoppingHeight,
                MachineWidth = woodChipper.MachineWidth,
                FlowMaterial = woodChipper.FlowMaterial,
                Description = woodChipper.Description
            }).ToList();

            return workWoodChippers;
        }
    }
}
