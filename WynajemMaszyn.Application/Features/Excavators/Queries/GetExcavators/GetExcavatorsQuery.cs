using MediatR;
using ErrorOr;
using WynajemMaszyn.Application.Features.Excavators.Queries.DTOs;


namespace WynajemMaszyn.Application.Features.Excavators.Queries.GetExcavators
{
        public record GetExcavatorsQuery(
        ) : IRequest<ErrorOr<GetExcavatorDto>>;
}
