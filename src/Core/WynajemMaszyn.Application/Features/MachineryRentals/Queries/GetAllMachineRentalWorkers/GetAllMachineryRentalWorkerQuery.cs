using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Features.MachineryRentals.Queries.DTOs;

namespace WynajemMaszyn.Application.Features.MachineryRentals.Queries.GetAllMachineRentalWorkers
{
    public record GetAllMachineryRentalWorkerQuery(
    ) : IRequest<ErrorOr<List<GetAllMachineryRentalDto>>>;
}
