using Microsoft.AspNetCore.Components;
using WynajemMaszyn.Application.Features.Enums;
using WynajemMaszyn.Application.Features.Excavators.Queries.DTOs;
using WynajemMaszyn.Application.Features.Excavators.Queries.GetExcavators;

namespace WynajemMaszyn.WebUI_server.Components.Pages.machines.Details
{
    partial class ExcavatorDetails
    {
        private GetExcavatorDto machinery = new GetExcavatorDto();

        [Parameter]
        [SupplyParameterFromQuery]
        public int? IdMachine { get; set; }


        protected override async Task OnInitializedAsync()
        {
            EnumsCustomer enumsCustomer = new EnumsCustomer();

                if (IdMachine is null)
                {
                    navigationManager.NavigateTo("/ExcavatorWorker");
                }
                var command = new GetExcavatorQuery(
                            (int)IdMachine
                            );
                var response = await Mediator.Send(command);

                var excavator = response.Match(
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

                    throw new Exception("Failed to retrieve excavator.");
                });

                machinery=excavator;
        }   

       
    }
}
