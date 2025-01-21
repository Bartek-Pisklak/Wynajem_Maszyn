using Microsoft.AspNetCore.Components;
using WynajemMaszyn.Application.Features.Enums;
using WynajemMaszyn.Application.Features.Excavators.Queries.DTOs;
using WynajemMaszyn.Application.Features.Excavators.Queries.GetExcavators;
using WynajemMaszyn.Application.Features.MachineryRentals.Command.AddMachineryCard;
using WynajemMaszyn.Application.Features.MachineryRentals.Command.DeleteMachineryCard;

namespace WynajemMaszyn.WebUI.Components.Pages.machines.Details
{
    partial class ExcavatorDetails
    {
        private GetExcavatorDto machinery = new GetExcavatorDto();
        private List<string> ImagePathList = new();
        private string CurrentImage { get; set; } = string.Empty;
        private bool IsLightboxVisible { get; set; } = false;


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
            ImagePathList = excavator.ImagePath;
            CurrentImage = ImagePathList[0];
        }


        private async void AddMachineToCard()
        {
            var command = new AddMachineryCardCommand(
                        (int)IdMachine,
                        "Excavator"
                       );
            var response = await Mediator.Send(command);

        }

        private async void DeleteMachineToCard()
        {
            var command = new DeleteMachineryCardCommand(
                        (int)IdMachine,
                        "Excavator"
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
