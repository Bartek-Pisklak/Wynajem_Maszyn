using ErrorOr;
using MediatR;

using WynajemMaszyn.Application.Features.Rollers.Queries.DTOs;

namespace WynajemMaszyn.Application.Features.Rollers.Queries.GetRollers
{
    public record GetRollerQuery(
        int Id
        ) : IRequest<ErrorOr<GetRollerDto>>;
}
