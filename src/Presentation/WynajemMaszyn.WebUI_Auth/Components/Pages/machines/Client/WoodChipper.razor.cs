using Microsoft.AspNetCore.WebUtilities;
using WynajemMaszyn.Application.Features.WoodChippers.Queries.DTOs;
using WynajemMaszyn.Application.Features.WoodChippers.Queries.GetAllWoodChippers;

namespace WynajemMaszyn.WebUI.Components.Pages.machines.Client
{
    partial class WoodChipper
    {
        private List<GetAllWoodChipperDto>? woodChipper;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var query = new GetAllWoodChipperQuery();
                var response = await Mediator.Send(query);

                woodChipper = response.Match(
                woodChipperResponse =>
                {
                    return woodChipperResponse;
                },
                errors =>
                {
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"Error: {error.Description} (Code: {error.Code})");
                    }

                    throw new Exception("Failed to retrieve woodchipper.");
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
            var url = QueryHelpers.AddQueryString("/WoodChipperDetails", new Dictionary<string, string?>
            {
                { "IdMachine", machineId.ToString() }
            });
            navigationManager.NavigateTo(url);
        }
    }
}
