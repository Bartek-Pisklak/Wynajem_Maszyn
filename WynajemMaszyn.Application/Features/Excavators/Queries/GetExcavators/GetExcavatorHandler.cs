using MediatR;
using ErrorOr;
using WynajemMaszyn.Application.Common.Errors;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.Features.Excavators.Queries.DTOs;
using WynajemMaszyn.Domain.Entities;


namespace WynajemMaszyn.Application.Features.Excavators.Queries.GetExcavators
{
    public class GetExcavatorHandler : IRequestHandler<GetExcavatorsQuery, ErrorOr<GetExcavatorDto>>
    {
        private readonly IExcavatorRepository _excavatorRepository;

        public GetExcavatorHandler(IExcavatorRepository excavatorRepository)
        {
            _excavatorRepository=excavatorRepository;
        }


        public async Task<ErrorOr<GetExcavatorDto>> Handle(GetExcavatorsQuery request, CancellationToken cancellationToken)
        {

            

            var excavator = await _excavatorRepository.GetExcavator(1);

            if (excavator == null) return Errors.Excavator.NotDataToDisplay;

            var workExcavators = new GetExcavatorDto
            {
                Id=excavator.Id,
                Name=excavator.Name,
                ProductionYear=excavator.ProductionYear,
                OperatingHours=excavator.OperatingHours,
                Weight= excavator.Weight,
                Engine = excavator.Engine,
                EnginePower = excavator.EnginePower,
                DrivingSpeed = excavator.DrivingSpeed
            };

            return workExcavators;
        }
    }
}
