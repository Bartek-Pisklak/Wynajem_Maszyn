using MediatR;
using WynajemMaszyn.Api.Data;

namespace WynajemMaszyn.WebUI.Data
{
    public class WoodChipperService : ApiController
    {
        private readonly ISender _mediator;

        public WoodChipperService(ISender mediator)
        {
            _mediator=mediator;
        }
    
    }
}
