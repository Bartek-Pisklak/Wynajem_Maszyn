using Microsoft.AspNetCore.WebUtilities;
using WynajemMaszyn.Application.Features.Excavators.Queries.DTOs;
using WynajemMaszyn.Application.Features.Excavators.Queries.GetAllExcavators;

namespace WynajemMaszyn.WebUI_server.Components.Pages.machines.Client
{
    partial class Excavator
    {
        private List<GetAllExcavatorDto>? excavator;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var query = new GetAllExcavatorQuery();
                var response = await Mediator.Send(query);


                excavator = response.Match(
                excavatorResponse =>
                {
                    return excavatorResponse;
                },
                errors =>
                {
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"Error: {error.Description} (Code: {error.Code})");
                    }
                    throw new Exception("Failed to retrieve excavators.");
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
            var url = QueryHelpers.AddQueryString("/ExcavatorDetails", new Dictionary<string, string?>
            {
                { "IdMachine", machineId.ToString() }
            });
            navigationManager.NavigateTo(url);
        }



    }
}
