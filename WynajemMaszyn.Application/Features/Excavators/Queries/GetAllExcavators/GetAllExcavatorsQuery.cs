using MediatR;
using ErrorOr;
using WynajemMaszyn.Application.Features.Excavators.Queries.DTOs;


namespace WynajemMaszyn.Application.Features.Excavators.Queries.GetAllExcavators
{
        public record GetAllExcavatorsQuery(
        ) : IRequest<ErrorOr<List<GetExcavatorDto>>>;
}
