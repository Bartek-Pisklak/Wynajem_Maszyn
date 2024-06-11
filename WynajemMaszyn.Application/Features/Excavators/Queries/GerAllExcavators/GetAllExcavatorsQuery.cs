using MediatR;
using WynajemMaszyn.Application.Features.Excavators.Queries.GetAllExcavators;

namespace WynajemMaszyn.Application.Features.Excavators.Queries.GerAllExcavators
{
    public record GetAllExcavatorsQuery(
        DisplayEventsData? Display
        ) : IRequest<ErrorOr<List<GetEventsDto>>>;

}
