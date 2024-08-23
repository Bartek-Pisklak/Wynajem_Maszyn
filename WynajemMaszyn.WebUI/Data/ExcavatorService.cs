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


        public async Task<List<GetExcavatorDto>> GetAllExcavators()
        {
            var query = new GetAllExcavatorsQuery();
            var response = await _mediator.Send(query);

            return response.Match(
                   ExcavatorResponse =>
                   {
                       // Jeśli operacja się powiodła, zwracamy listę excavatorów
                       return ExcavatorResponse;
                   },
                   errors =>
                   {
                       // Jeśli są błędy, logujemy je i rzucamy wyjątek
                       foreach (var error in errors)
                       {
                           Console.WriteLine($"Error: {error.Description} (Code: {error.Code})");
                       }

                       // Możesz obsłużyć błędy w inny sposób, np. zwrócić null lub pustą listę
                       throw new Exception("Failed to retrieve excavators.");
                   }
               );

        }

    }
}
