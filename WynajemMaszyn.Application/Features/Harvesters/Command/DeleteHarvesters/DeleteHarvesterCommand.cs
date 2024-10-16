using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.HarversterAnswer;


namespace WynajemMaszyn.Application.Features.Harvesters.Command.DeleteHarvesters
{
    public record DeleteHarvesterCommand
    (
    int Id

        ): IRequest<ErrorOr<HarvesterResponse>>;
}
