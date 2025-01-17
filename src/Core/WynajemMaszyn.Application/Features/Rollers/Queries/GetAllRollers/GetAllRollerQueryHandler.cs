using ErrorOr;
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
        private readonly IMachineryRepository _machineryRepository;
        public GetAllRollerQueryHandler(IRollerRepository rollerRepository,
            IMachineryRepository machineryRepository)
        {
            _rollerRepository = rollerRepository;
            _machineryRepository=machineryRepository;
        }

        public async Task<ErrorOr<List<GetAllRollerDto>>> Handle(GetAllRollerQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Roller> rollers;

            rollers = await _rollerRepository.GetAllRoller();


            if (!rollers.Any()) return Errors.Roller.NotDataToDisplay;

            Machinery whatMachinery = new Machinery();
            whatMachinery.RollerId = 1;
            var dateBusyMachine = await _machineryRepository.GetDateMachineryBusy(whatMachinery);

            List<GetAllRollerDto> workRollers = rollers.Select(x => new GetAllRollerDto
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

            return workRollers;
        }
    }
}
