using Microsoft.AspNetCore.WebUtilities;
using WynajemMaszyn.Application.Features.Rollers.Queries.DTOs;
using WynajemMaszyn.Application.Features.Rollers.Queries.GetAllRollers;

namespace WynajemMaszyn.WebUI.Components.Pages.machines.Client
{
    partial class Roller
    {

        private List<GetAllRollerDto>? roller;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var query = new GetAllRollerQuery();
                var response = await Mediator.Send(query);

                roller = response.Match(
                rollerResponse =>
                {
                    return rollerResponse;
                },
                errors =>
                {
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"Error: {error.Description} (Code: {error.Code})");
                    }

                    throw new Exception("Failed to retrieve rollers.");
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
            var url = QueryHelpers.AddQueryString("/RollerDetails", new Dictionary<string, string?>
            {
                { "IdMachine", machineId.ToString() }
            });
            navigationManager.NavigateTo(url);
        }
    }
}
