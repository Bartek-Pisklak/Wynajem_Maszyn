using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Features.WoodChippers.Queries.DTOs;

namespace WynajemMaszyn.Application.Features.WoodChippers.Queries.GetWoodChippers
{
    public record class GetWoodChipperQuery(
        int Id
        ):IRequest<ErrorOr<GetWoodChipperDto>>;
}
