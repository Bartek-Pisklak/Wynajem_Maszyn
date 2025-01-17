using MediatR;
using ErrorOr;
using WynajemMaszyn.Application.Common.Errors;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.Features.Excavators.Queries.DTOs;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Features.Excavators.Queries.GetAllExcavators
{
    public class GetAllExcavatorQueryHandler : IRequestHandler<GetAllExcavatorQuery, ErrorOr<List<GetAllExcavatorDto>>>
    {
        private readonly IExcavatorRepository _excavatorRepository;
        private readonly IMachineryRepository _machineryRepository;

        public GetAllExcavatorQueryHandler(IExcavatorRepository excavatorRepository,
            IMachineryRepository machineryRepository)
        {
            _excavatorRepository=excavatorRepository;
            _machineryRepository=machineryRepository;
        }


        public async Task<ErrorOr<List<GetAllExcavatorDto>>> Handle(GetAllExcavatorQuery request, CancellationToken cancellationToken)
        {
            
            IEnumerable<Excavator> excavators;

            excavators = await _excavatorRepository.GetAllExcavator();

            Machinery whatMachinery = new Machinery();
            whatMachinery.ExcavatorId = 1;
            var dateBusyMachine = await _machineryRepository.GetDateMachineryBusy(whatMachinery);

            if (!excavators.Any()) return Errors.Excavator.NotDataToDisplay;

            List<GetAllExcavatorDto> workExcavators = excavators.Select(x => new GetAllExcavatorDto
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
                IsRepair = x.IsRepair,

                }).ToList();


            return workExcavators;
        }
    }
}
