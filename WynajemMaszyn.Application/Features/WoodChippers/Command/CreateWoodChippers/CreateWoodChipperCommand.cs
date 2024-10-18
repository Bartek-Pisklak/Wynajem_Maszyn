using ErrorOr;
using MediatR;

using WynajemMaszyn.Application.Contracts.WoodChipperAnswer;

namespace WynajemMaszyn.Application.Features.WoodChippers.Command.CreateWoodChippers
{
    public record CreateWoodChipperCommand
    (
        string Name
        ) : IRequest<ErrorOr<WoodChipperResponse>>; 
}
