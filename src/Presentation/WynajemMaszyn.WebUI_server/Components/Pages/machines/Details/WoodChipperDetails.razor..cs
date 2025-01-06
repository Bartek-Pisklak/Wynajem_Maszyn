using Microsoft.AspNetCore.Components;
using WynajemMaszyn.Application.Features.WoodChippers.Queries.DTOs;
using WynajemMaszyn.Application.Features.WoodChippers.Queries.GetWoodChippers;

namespace WynajemMaszyn.WebUI_server.Components.Pages.machines.Details
{
    partial class WoodChipperDetails
    {
        private GetWoodChipperDto machinery = new GetWoodChipperDto();

        [Parameter]
        [SupplyParameterFromQuery]
        public int? IdMachine { get; set; }


        protected override async Task OnInitializedAsync()
        {

            if (IdMachine is null)
            {
                navigationManager.NavigateTo("/WoodChipper");
            }
            var command = new GetWoodChipperQuery(
                        (int)IdMachine
                        );
            var response = await Mediator.Send(command);

            var woodChipper = response.Match(
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

                throw new Exception("Failed to retrieve roller.");
            });

            machinery=woodChipper;

        }


        private void AddMachineToCard()
        {


        }
    }
}
