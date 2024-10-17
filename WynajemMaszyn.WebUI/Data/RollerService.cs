using MediatR;
using WynajemMaszyn.Api.Data;

namespace WynajemMaszyn.WebUI.Data
{
    public class RollerService : ApiController
    {
        private readonly ISender _mediator;

        public RollerService(ISender mediator)
        {
            _mediator=mediator;
        }


    }
}
