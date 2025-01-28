using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Features.MachineryRentals.Queries.DTOs;

namespace WynajemMaszyn.Application.Features.MachineryRentals.Queries.GetMachineRentals
{
    public record GetMachineryRentalQuery(
        int IdCard
        ) : IRequest<ErrorOr<GetMachineryRentalDto>>;
}
