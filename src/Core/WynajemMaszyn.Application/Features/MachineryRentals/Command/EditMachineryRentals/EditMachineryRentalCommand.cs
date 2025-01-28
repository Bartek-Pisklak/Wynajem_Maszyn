using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.MachineryRentalAnswer;


namespace WynajemMaszyn.Application.Features.MachineryRentals.Command.EditMachineRentals
{
    public record EditMachineryRentalCommand(

    ) : IRequest<ErrorOr<MachineryRentalResponse>>;
}
