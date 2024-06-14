﻿using MediatR;
using ErrorOr;
using WynajemMaszyn.Application.Features.Excavators.Queries.DTOs;


namespace WynajemMaszyn.Application.Features.Excavators.Queries.GetAllExcavators
{
        public record GetExcavatorsQuery(
        ) : IRequest<ErrorOr<List<GetExcavatorDto>>>;
}
