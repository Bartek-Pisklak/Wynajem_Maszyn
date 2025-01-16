using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using WynajemMaszyn.Application.Contracts.WoodChipperAnswer;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Features.WoodChippers.Command.DeleteWoodChippers
{
    public record DeleteWoodChipperCommand
    (
        HttpContext context,
        int Id
        ) : IRequest<ErrorOr<WoodChipperResponse>>;
}
