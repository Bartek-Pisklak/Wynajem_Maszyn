using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Application.Contracts.WoodChipperAnswer;

namespace WynajemMaszyn.Application.Features.WoodChippers.Command.DeleteWoodChippers
{
    public record DeleteWoodChipperCommand
    (
        int Id
        ) : IRequest<ErrorOr<WoodChipperResponse>>;
}
