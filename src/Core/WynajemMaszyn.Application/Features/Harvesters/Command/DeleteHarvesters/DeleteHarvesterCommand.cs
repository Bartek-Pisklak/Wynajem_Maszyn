using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using WynajemMaszyn.Application.Contracts.HarversterAnswer;
using WynajemMaszyn.Domain.Entities;


namespace WynajemMaszyn.Application.Features.Harvesters.Command.DeleteHarvesters
{
    public record DeleteHarvesterCommand
    (
            HttpContext context,
            int Id

        ): IRequest<ErrorOr<HarvesterResponse>>;
}
