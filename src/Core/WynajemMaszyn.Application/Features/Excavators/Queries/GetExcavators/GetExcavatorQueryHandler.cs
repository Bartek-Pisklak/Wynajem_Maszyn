using MediatR;
using ErrorOr;
using WynajemMaszyn.Application.Common.Errors;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.Features.Excavators.Queries.DTOs;
using WynajemMaszyn.Domain.Entities;


namespace WynajemMaszyn.Application.Features.Excavators.Queries.GetExcavators
{
    public class GetExcavatorQueryHandler : IRequestHandler<GetExcavatorQuery, ErrorOr<GetExcavatorDto>>
    {
        private readonly IExcavatorRepository _excavatorRepository;
        private readonly IMachineryRepository _machineryRepository;

        public GetExcavatorQueryHandler(IExcavatorRepository excavatorRepository,
            IMachineryRepository machineryRepository)
        {
            _excavatorRepository=excavatorRepository;
            _machineryRepository=machineryRepository;
        }


        public async Task<ErrorOr<GetExcavatorDto>> Handle(GetExcavatorQuery request, CancellationToken cancellationToken)
        {     
            var excavator = await _excavatorRepository.GetExcavator(request.Id);

            if (excavator == null) return Errors.Excavator.NotDataToDisplay;

            var machineBusy = new Machinery();
            machineBusy.ExcavatorId = request.Id;

            var dateBusyMachine = await _machineryRepository.GetDateOneMachineryBusy(machineBusy);

            var workExcavators = new GetExcavatorDto
            {
                Id = excavator.Id,
                Name = excavator.Name,
                TypeExcavator = excavator.TypeExcavator,
                TypeChassis = excavator.TypeChassis,
                RentalPricePerDay = excavator.RentalPricePerDay,
                ProductionYear = excavator.ProductionYear,
                OperatingHours = excavator.OperatingHours,
                Weight = excavator.Weight,
                Engine = excavator.Engine,
                EnginePower = excavator.EnginePower,
                DrivingSpeed = excavator.DrivingSpeed,
                FuelConsumption = excavator.FuelConsumption,
                FuelType = excavator.FuelType,
                Gearbox = excavator.Gearbox,
                MaxDiggingDepth = excavator.MaxDiggingDepth,
                Description = excavator.Description,
                ImagePath = excavator.ImagePath.Split(",").ToList(),
                DateBusy = dateBusyMachine,
                IsRepair = excavator.IsRepair,
            };

            return workExcavators;
        }
    }
}
