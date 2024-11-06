using MediatR;
using ErrorOr;
using WynajemMaszyn.Application.Features.Excavators.Queries.DTOs;


namespace WynajemMaszyn.Application.Features.Excavators.Queries.GetExcavators
{
        public record GetExcavatorQuery(
            int Id
        ) : IRequest<ErrorOr<GetExcavatorDto>>;
}
