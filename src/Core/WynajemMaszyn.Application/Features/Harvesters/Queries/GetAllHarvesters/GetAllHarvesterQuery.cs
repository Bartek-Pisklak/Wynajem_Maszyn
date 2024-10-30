using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Features.Harvesters.Queries.DTOs;

namespace WynajemMaszyn.Application.Features.Harvesters.Queries.GetAllHarvesters
{
    public record GetAllHarvesterQuery(
        ) : IRequest<ErrorOr<List<GetAllHarvesterDto>>>;
}
