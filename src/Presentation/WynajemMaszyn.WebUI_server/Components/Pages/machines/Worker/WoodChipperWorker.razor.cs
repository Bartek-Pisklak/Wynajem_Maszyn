using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using WynajemMaszyn.Application.Features.WoodChippers.Command.DeleteWoodChippers;
using WynajemMaszyn.Application.Features.WoodChippers.Queries.DTOs;
using WynajemMaszyn.Application.Features.WoodChippers.Queries.GetAllWoodChippers;

namespace WynajemMaszyn.WebUI_server.Components.Pages.machines.Worker
{
    partial class WoodChipperWorker
    {
        [CascadingParameter]
        private HttpContext HttpContext { get; set; } = default!;

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

        private void AddWoodChipper()
        {
            navigationManager.NavigateTo("/WoodChipperForm");
        }
        private void EditWoodChipper(int idMachine)
        {
            string action = "edit";
            var url = QueryHelpers.AddQueryString("/WoodChipperForm", new Dictionary<string, string?>
            {
                { "IdMachine", idMachine.ToString() },
                { "Action", action }
            });
            navigationManager.NavigateTo(url);
        }
        private void DeleteWoodChipper(int idMachine)
        {
            var command = new DeleteWoodChipperCommand(HttpContext, idMachine);

            var response = Mediator.Send(command);
            navigationManager.NavigateTo(navigationManager.Uri, forceLoad: true);
            Console.WriteLine(response.ToString());
        }


    }
}
