using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Features.Rollers.Queries.DTOs;

namespace WynajemMaszyn.Application.Features.Rollers.Queries.GetAllRollers
{
    public record GetAllRollerQuery(
        ) : IRequest<ErrorOr<List<GetAllRollerDto>>>;
}
