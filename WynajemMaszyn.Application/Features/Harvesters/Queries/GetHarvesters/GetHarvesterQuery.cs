using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Features.Harvesters.Queries.DTOs;

namespace WynajemMaszyn.Application.Features.Harvesters.Queries.GetHarvesters
{
    public record GetHarvesterQuery (
        int Id
        ) : IRequest<ErrorOr<GetHarvesterDto>>;
}
