using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Features.MachineryRentals.Queries.DTOs;


namespace WynajemMaszyn.Application.Features.MachineryRentals.Queries.GetAllMachineRentals
{
    public record GetAllMachineryRentalClientQuery(
        ) : IRequest<ErrorOr<List<GetAllMachineryRentalDto>>>;
}
