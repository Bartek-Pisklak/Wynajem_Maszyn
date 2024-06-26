﻿using MediatR;
using ErrorOr;
using WynajemMaszyn.Application.Common.Errors;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.Features.Excavators.Queries.DTOs;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Features.Excavators.Queries.GetAllExcavators
{
    public class GetAllExcavatorQueryHandler : IRequestHandler<GetAllExcavatorsQuery, ErrorOr<List<GetExcavatorDto>>>
    {
        private readonly IExcavatorRepository _excavatorRepository;

        public GetAllExcavatorQueryHandler(IExcavatorRepository excavatorRepository)
        {
            _excavatorRepository=excavatorRepository;
        }


        public async Task<ErrorOr<List<GetExcavatorDto>>> Handle(GetAllExcavatorsQuery request, CancellationToken cancellationToken)
        {
            
            IEnumerable<Excavator> excavators;

            //excavators = await _excavatorRepository.GetAllExcavator();
            excavators = _excavatorRepository.GetAllExcavator();

            if (!excavators.Any()) return Errors.Excavator.NotDataToDisplay;

            List<GetExcavatorDto> workExcavators = excavators.Select(x => new GetExcavatorDto
            {
                Id=x.Id,
                Name=x.Name,
                ProductionYear=x.ProductionYear,
                OperatingHours=x.OperatingHours,
                Weight= x.Weight,
                Engine = x.Engine,
                EnginePower = x.EnginePower,
                DrivingSpeed = x.DrivingSpeed
            }).ToList();

            return workExcavators;
        }
    }
}
