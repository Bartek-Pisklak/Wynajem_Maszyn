using MediatR;
using Microsoft.EntityFrameworkCore;
using WynajemMaszyn.Api.Data;
using WynajemMaszyn.Infrastructure;

namespace WynajemMaszyn.WebUI.Data
{
    public class RollerService : ApiController
    {
        private readonly ISender _mediator;
        private readonly ApplicationDbContext _dbContext;

        public RollerService(ISender mediator)
        {
            _mediator=mediator;
        }


    }
}
