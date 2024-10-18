using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Application.Contracts.MachineryRentalAnswer;

namespace WynajemMaszyn.Application.Features.MachineryRentals.Command.EditMachineRentals
{
    public record EditMachineRentalCommand(


    ) : IRequest<ErrorOr<MachineryRentalResponse>>;
}
