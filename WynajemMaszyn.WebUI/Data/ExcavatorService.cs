using MediatR;
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


        public async Task<List<GetExcavatorDto>> GetAllExcavators()
        {
            var query = new GetAllExcavatorQuery();
            var response = await _mediator.Send(query);

            return response.Match(
                   ExcavatorResponse =>
                   {
                       return ExcavatorResponse;
                   },
                   errors =>
                   {
                       foreach (var error in errors)
                       {
                           Console.WriteLine($"Error: {error.Description} (Code: {error.Code})");
                       }

                       // Możesz obsłużyć błędy w inny sposób np. zwrócić null lub pustą listę
                       throw new Exception("Failed to retrieve excavators.");
                   }
               );

        }

    }
}
