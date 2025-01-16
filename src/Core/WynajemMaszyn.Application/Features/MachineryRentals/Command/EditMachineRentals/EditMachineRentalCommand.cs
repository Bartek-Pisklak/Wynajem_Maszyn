using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.MachineryRentalAnswer;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Features.MachineryRentals.Command.EditMachineRentals
{
    public record EditMachineRentalCommand(
            User user

    ) : IRequest<ErrorOr<MachineryRentalResponse>>;
}
