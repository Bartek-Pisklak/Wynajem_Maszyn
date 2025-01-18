using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.MachineryRentalAnswer;

namespace WynajemMaszyn.Application.Features.MachineryRentals.Command.AddMachineryCard
{
    public record AddMachineryCardCommand
    (
        
        int IdMachine,
        string TypeMachine
        ) : IRequest<ErrorOr<MachineryRentalResponse>>;
}
