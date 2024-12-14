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

        public GetAllExcavatorQueryHandler(IExcavatorRepository excavatorRepository)
        {
            _excavatorRepository=excavatorRepository;
        }


        public async Task<ErrorOr<List<GetAllExcavatorDto>>> Handle(GetAllExcavatorQuery request, CancellationToken cancellationToken)
        {
            
            IEnumerable<Excavator> excavators;

            excavators = await _excavatorRepository.GetAllExcavator();

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
                ImagePath=x.ImagePath

                }).ToList();


            return workExcavators;
        }
    }
}
