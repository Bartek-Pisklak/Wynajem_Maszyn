using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.MachineryRentalAnswer;

namespace WynajemMaszyn.Application.Features.MachineryRentals.Command.DeleteMachineryCard
{
    public record DeleteMachineryCardCommand
    (
        int IdMachine,
        string TypeMachine
        ) : IRequest<ErrorOr<MachineryRentalResponse>>;
}
