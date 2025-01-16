using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using WynajemMaszyn.Application.Contracts.MachineryRentalAnswer;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Features.MachineryRentals.Command.CreateMachineRentals
{
    public record CreateMachineRentalCommand
    (
            HttpContext context


    ) :IRequest<ErrorOr<MachineryRentalResponse>>;
}
