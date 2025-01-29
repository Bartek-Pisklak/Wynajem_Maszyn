


using Microsoft.AspNetCore.Components;
using WynajemMaszyn.Application.Features.Enums;
using WynajemMaszyn.Application.Features.MachineryRentals.Queries.DTOs;
using WynajemMaszyn.Application.Features.MachineryRentals.Queries.GetMachineRentals;

namespace WynajemMaszyn.WebUI.Components.Pages.Rental
{
    partial class MachineRentalClient
    {
        private GetMachineryRentalDto MachineRentals = new GetMachineryRentalDto();

        [Parameter]
        [SupplyParameterFromQuery]
        public int? IdMachineCard { get; set; }

        protected override async Task OnInitializedAsync()
        {
            EnumsCustomer enumsCustomer = new EnumsCustomer();
            if (IdMachineCard is null)
            {
                navigationManager.NavigateTo("/MachineryRentalClientList");
            }

            var command = new GetMachineryRentalQuery((int)IdMachineCard);
            var response = await Mediator.Send(command);

            var machinery = response.Match(
            machineryResponse =>
            {
                return machineryResponse;
            },
            errors =>
            {
                foreach (var error in errors)
                {
                    Console.WriteLine($"Error: {error.Description} (Code: {error.Code})");
                }

                throw new Exception("Failed to retrieve excavator.");
            });

            MachineRentals = machinery;
        }


    }
}
