using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Features.Harvesters.Queries.DTOs;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;

namespace WynajemMaszyn.Application.Features.Harvesters.Queries.GetAllHarvesters
{
    public class GetAllHarvesterQueryHandler : IRequestHandler<GetAllHarvesterQuery, ErrorOr<List<GetAllHarvesterDto>>>
    {
        private readonly IHarvesterRepository _harvesterRepository;
        private readonly IMachineryRepository _machineryRepository;

        public GetAllHarvesterQueryHandler(IHarvesterRepository harvesterRepository,
            IMachineryRepository machineryRepository)
        {
            _harvesterRepository= harvesterRepository;
            _machineryRepository=machineryRepository;
        }

        public async  Task<ErrorOr<List<GetAllHarvesterDto>>> Handle(GetAllHarvesterQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Harvester> harvester;
            harvester = await _harvesterRepository.GetAllHarvester();
            if(!harvester.Any()) return Errors.Harvester.NotDataToDisplay;
            Machinery whatMachinery = new Machinery();
            whatMachinery.HarvesterId = 1;
            var dateBusyMachine = await _machineryRepository.GetDateMachineryBusy(whatMachinery);

            List<GetAllHarvesterDto> workHarvesters = harvester.Select(x => new GetAllHarvesterDto
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


            return workHarvesters;
        }
    }
}