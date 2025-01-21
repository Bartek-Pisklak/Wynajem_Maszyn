using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.ExcavatorAnswer;
namespace WynajemMaszyn.Application.Features.Excavators.Command.DeleteExcavators
{
    public record DeleteExcavatorCommand
   (
       int Id
       ) : IRequest<ErrorOr<ExcavatorResponse>>;
}
