using Microsoft.AspNetCore.WebUtilities;
using WynajemMaszyn.Application.Features.Harvesters.Queries.DTOs;
using WynajemMaszyn.Application.Features.Harvesters.Queries.GetAllHarvesters;

namespace WynajemMaszyn.WebUI_server.Components.Pages.machines.Client
{
    partial class Harvester
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



        private void NavigateToDetails(int machineId)
        {
            var url = QueryHelpers.AddQueryString("/HarvesterDetails", new Dictionary<string, string?>
            {
                { "IdMachine", machineId.ToString() }
            });
            navigationManager.NavigateTo(url);
        }


    }
}
