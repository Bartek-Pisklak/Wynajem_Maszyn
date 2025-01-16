using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Features.WoodChippers.Queries.DTOs;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.Common.Errors;

namespace WynajemMaszyn.Application.Features.WoodChippers.Queries.GetWoodChippers
{
    public class GetWoodChipperQueryHandler : IRequestHandler<GetWoodChipperQuery, ErrorOr<GetWoodChipperDto>>
    {
        private readonly IWoodChipperRepository _woodChipperRepository;

        public GetWoodChipperQueryHandler(IWoodChipperRepository woodChipperRepository)
        {
            _woodChipperRepository = woodChipperRepository;
        }

        public async Task<ErrorOr<GetWoodChipperDto>> Handle(GetWoodChipperQuery request, CancellationToken cancellationToken)
        {
            var woodChipper = await _woodChipperRepository.GetWoodChipper(request.Id);

            if (woodChipper == null) return Errors.WoodChipper.NotDataToDisplay;

            var workwoodChipper = new GetWoodChipperDto
            {
                Id = woodChipper.Id,
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
                ImagePath = woodChipper.ImagePath.Split(",").ToList(),
                Description = woodChipper.Description,
                IsRepair = woodChipper.IsRepair
            };

            return workwoodChipper;
        }
    }
}
