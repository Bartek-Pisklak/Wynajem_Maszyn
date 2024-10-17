using MediatR;
using WynajemMaszyn.Api.Data;

namespace WynajemMaszyn.WebUI.Data
{
    public class HarvesterService : ApiController
    {
        private readonly ISender _mediator;

        public HarvesterService(ISender mediator)
        {
            _mediator=mediator;
        }



    }
}
