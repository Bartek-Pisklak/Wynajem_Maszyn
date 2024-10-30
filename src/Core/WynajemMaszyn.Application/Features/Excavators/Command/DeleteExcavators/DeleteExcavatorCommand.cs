using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Application.Contracts.ExcavatorAnswer;

namespace WynajemMaszyn.Application.Features.Excavators.Command.DeleteExcavators
{
    public record DeleteExcavatorCommand
   (
       int Id
       ) : IRequest<ErrorOr<ExcavatorResponse>>;
}
