using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using WynajemMaszyn.Application.Contracts.ExcavatorAnswer;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Features.Excavators.Command.DeleteExcavators
{
    public record DeleteExcavatorCommand
   (
       HttpContext context,
       int Id
       ) : IRequest<ErrorOr<ExcavatorResponse>>;
}
