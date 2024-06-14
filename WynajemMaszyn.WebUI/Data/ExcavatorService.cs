using MediatR;
using Microsoft.AspNetCore.Mvc;
using WynajemMaszyn.Application.Features.Excavators.Queries.GetAllExcavators;
using WynajemMaszyn.Application.Features.Excavators.Queries.DTOs;
using WynajemMaszyn.Api.Data;


namespace WynajemMaszyn.WebUI.Data
{
    public class ExcavatorService : ApiController
    {
        private readonly ISender _mediator;

        public ExcavatorService(ISender mediator) 
        {
            _mediator=mediator;
        }


        public async Task<List<GetExcavatorDto>> GetAllExcavator([FromQuery] GetExcavatorsQuery query)
        {
            var response = await _mediator.Send(query);

            return (List<GetExcavatorDto>)response.Match(
                        WorkTaskResponse => Ok(WorkTaskResponse),
                        errors => Problem(errors));
        }
    }

}
