using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Features.WoodChippers.Queries.DTOs;

namespace WynajemMaszyn.Application.Features.WoodChippers.Queries.GetAllWoodChippers
{
    public record GetAllWoodChipperQuery(

        ) : IRequest<ErrorOr<List<GetAllWoodChipperDto>>>;

}
