using Microsoft.AspNetCore.WebUtilities;
using WynajemMaszyn.Application.Features.Harvesters.Command.DeleteHarvesters;
using WynajemMaszyn.Application.Features.Harvesters.Queries.DTOs;
using WynajemMaszyn.Application.Features.Harvesters.Queries.GetAllHarvesters;


namespace WynajemMaszyn.WebUI_server.Components.Pages.machines.Worker
{
    partial class HarvesterWorker
    {

        private List<GetAllHarvesterDto>? harvester;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var query = new GetAllHarvesterQuery();
                var response = await Mediator.Send(query);


                harvester = response.Match(
                harvesterResponse =>
                {
                    return harvesterResponse;
                },
                errors =>
                {
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"Error: {error.Description} (Code: {error.Code})");
                    }

                    // Możesz zwrócić pustą listę lub obsłużyć błędy w inny sposób
                    throw new Exception("Failed to retrieve harvesters.");
                }
                );
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"Invalid cast exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unhandled exception: {ex.Message}");
            }
        }


        private void AddHarvester()
        {
            navigationManager.NavigateTo("/HarvesterForm");
        }

        private void EditHarvester(int idMachine)
        {
            string action = "edit";
            var url = QueryHelpers.AddQueryString("/HarvesterForm", new Dictionary<string, string?>
            {
                { "IdMachine", idMachine.ToString() },
                { "Action", action }
            });
            navigationManager.NavigateTo(url);
        }

        private void DeleteHarvester(int idMachine)
        {
            var command = new DeleteHarvesterCommand(idMachine);

            var response = Mediator.Send(command);
            navigationManager.NavigateTo(navigationManager.Uri, forceLoad: true);
            Console.WriteLine(response.ToString());
        }
    }
}
