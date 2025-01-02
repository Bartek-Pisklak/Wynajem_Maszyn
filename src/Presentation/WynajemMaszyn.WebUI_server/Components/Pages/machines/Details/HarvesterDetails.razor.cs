using Microsoft.AspNetCore.Components;
using WynajemMaszyn.Application.Features.Enums;
using WynajemMaszyn.Application.Features.Harvesters.Queries.DTOs;
using WynajemMaszyn.Application.Features.Harvesters.Queries.GetHarvesters;

namespace WynajemMaszyn.WebUI_server.Components.Pages.machines.Details
{
    partial class HarvesterDetails
    {
        private GetHarvesterDto machinery = new GetHarvesterDto();

        [Parameter]
        [SupplyParameterFromQuery]
        public int? IdMachine { get; set; }



        protected override async Task OnInitializedAsync()
        {
            EnumsCustomer enumsCustomer = new EnumsCustomer();

            if (IdMachine is null)
            {
                navigationManager.NavigateTo("/Harvester");
            }

            var command = new GetHarvesterQuery(
                        (int)IdMachine
                        );
            var response = await Mediator.Send(command);

            var Harvester = response.Match(
            HarvesterResponse =>
            {
                return HarvesterResponse;
            },
            errors =>
            {
                foreach (var error in errors)
                {
                    Console.WriteLine($"Error: {error.Description} (Code: {error.Code})");
                }

                throw new Exception("Failed to retrieve Harvester.");
            });

            machinery=Harvester;


        }
    }
}
