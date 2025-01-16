using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Application.Contracts.MachineryRentalAnswer;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Features.MachineryRentals.Command.DeleteMachineRentals
{
    public record DeleteMachineRentalCommand(
        HttpContext context,
        int Id
    ) : IRequest<ErrorOr<MachineryRentalResponse>>;
}
