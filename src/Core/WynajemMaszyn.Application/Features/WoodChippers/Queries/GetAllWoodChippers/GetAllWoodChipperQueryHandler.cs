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
        private readonly IMachineryRepository _machineryRepository;

        public GetAllWoodChipperQueryHandler(IWoodChipperRepository woodChipperRepository,
            IMachineryRepository machineryRepository)
        {
            _woodChipperRepository = woodChipperRepository;
            _machineryRepository=machineryRepository;
        }

        public async Task<ErrorOr<List<GetAllWoodChipperDto>>> Handle(GetAllWoodChipperQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<WoodChipper> woodChippers;

            woodChippers = await _woodChipperRepository.GetAllWoodChipper();
            if (!woodChippers.Any()) return Errors.WoodChipper.NotDataToDisplay;

            Machinery whatMachinery = new Machinery();
            whatMachinery.WoodChipperId = 1;
            var dateBusyMachine = await _machineryRepository.GetDateMachineryBusy(whatMachinery);

            List<GetAllWoodChipperDto> workWoodChippers = woodChippers.Select(x => new GetAllWoodChipperDto
            {
                Id=x.Id,
                Name=x.Name,
                ProductionYear=x.ProductionYear,
                OperatingHours=x.OperatingHours,
                Weight= x.Weight,
                Engine = x.Engine,
                EnginePower = x.EnginePower,
                DrivingSpeed = x.DrivingSpeed,
                RentalPricePerDay=x.RentalPricePerDay,
                ImagePath = x.ImagePath.Split(",").FirstOrDefault(),
                DateBusyAll = dateBusyMachine,
                IsRepair =x.IsRepair,
            }).ToList();

            return workWoodChippers;
        }
    }
}
