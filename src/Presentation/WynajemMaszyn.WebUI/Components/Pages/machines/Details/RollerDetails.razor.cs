using Microsoft.AspNetCore.Components;
using WynajemMaszyn.Application.Features.Enums;
using WynajemMaszyn.Application.Features.Rollers.Queries.DTOs;
using WynajemMaszyn.Application.Features.Rollers.Queries.GetRollers;

namespace WynajemMaszyn.WebUI.Components.Pages.machines.Details
{
    partial class RollerDetails
    {
        private GetRollerDto machinery = new GetRollerDto();

        [Parameter]
        [SupplyParameterFromQuery]
        public int? IdMachine { get; set; }



        protected override async Task OnInitializedAsync()
        {
            EnumsCustomer enumsCustomer = new EnumsCustomer();


            if (IdMachine is null)
            {
                navigationManager.NavigateTo("/Roller");
            }
            var command = new GetRollerQuery(
                        (int)IdMachine
                        );
            var response = await Mediator.Send(command);

            var roller = response.Match(
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

                throw new Exception("Failed to retrieve roller.");
            });

            machinery=roller;

        }


        private void AddMachineToCard()
        {


        }
    }
}
