using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.MachineryRentalAnswer;

namespace WynajemMaszyn.Application.Features.MachineryRentals.Command.CreateMachineRentals
{
    public record CreateMachineRentalCommand
    (
        
        
    ) :IRequest<ErrorOr<MachineryRentalResponse>>;
}
