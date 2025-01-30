using Microsoft.AspNetCore.Components;
using MudBlazor;
using WynajemMaszyn.Application.Features.Enums;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.DTOs;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.GetExcavatorBuckets;
using WynajemMaszyn.Application.Features.MachineryRentals.Command.AddMachineryCard;
using WynajemMaszyn.Application.Features.MachineryRentals.Command.DeleteMachineryCard;

namespace WynajemMaszyn.WebUI.Components.Pages.machines.Details
{
    partial class ExcavatorBucketDetails
    {
        private GetExcavatorBucketDto bucket = new GetExcavatorBucketDto();
        private List<string> ImagePathList= new();
        private string CurrentImage { get; set; } = string.Empty;
        private bool IsLightboxVisible { get; set; } = false;


        private string CheckDate(DateTime date)
        {
            if( bucket.DateBusy is not null)
            {
                foreach ((DateTime start, DateTime end) m in bucket.DateBusy)
                {
                    if (m.start <= date && m.end >= date)
                    {
                        return "busy-day";
                    }
                }
            }
            return string.Empty;
        }



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
            ImagePathList= ExcavatorBucket.ImagePath;
            CurrentImage = ImagePathList[0];

        }


        private async void AddMachineToCard()
        {
            var command = new AddMachineryCardCommand(
                        (int)IdMachine,
                        "ExcavatorBucket"
                       );
            var response = await Mediator.Send(command);

        }

        private async void DeleteMachineToCard()
        {
            var command = new DeleteMachineryCardCommand(
                        (int)IdMachine,
                        "ExcavatorBucket"
                       );
            var response = await Mediator.Send(command);

        }




        private void ChangeImage(string newImagePath)
        {
            CurrentImage = newImagePath;
        }

        private void ShowImageInLightbox()
        {
            IsLightboxVisible = true;
        }

        private void HideLightbox()
        {
            IsLightboxVisible = false;
        }
    }
}
