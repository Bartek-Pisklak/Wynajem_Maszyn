using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using WynajemMaszyn.Application.Features.Enums;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.DTOs;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.GetExcavatorBuckets;

namespace WynajemMaszyn.WebUI.Components.Pages.machines.Details
{
    partial class ExcavatorBucketDetails
    {
        private GetExcavatorBucketDto bucket = new GetExcavatorBucketDto();

        [Parameter]
        [SupplyParameterFromQuery]
        public int? IdMachine { get; set; }


        protected override async Task OnInitializedAsync()
        {
            EnumsCustomer enumsCustomer = new EnumsCustomer();


            if (IdMachine is null)
            {
                navigationManager.NavigateTo("/ExcavatorBucket");
            }
            var command = new GetExcavatorBucketQuery(
                        (int)IdMachine
                        );
            var response = await Mediator.Send(command);

            var ExcavatorBucket = response.Match(
            ExcavatorBucketResponse =>
            {
                return ExcavatorBucketResponse;
            },
            errors =>
            {
                foreach (var error in errors)
                {
                    Console.WriteLine($"Error: {error.Description} (Code: {error.Code})");
                }

                throw new Exception("Failed to retrieve ExcavatorBucket.");
            });

            bucket = ExcavatorBucket;
        }


        private void AddMachineToCard()
        {


        }

    }
}
