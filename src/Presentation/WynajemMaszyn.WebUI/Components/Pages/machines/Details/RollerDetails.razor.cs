using Microsoft.AspNetCore.Components;
using WynajemMaszyn.Application.Features.Enums;
using WynajemMaszyn.Application.Features.MachineryRentals.Command.AddMachineryCard;
using WynajemMaszyn.Application.Features.MachineryRentals.Command.DeleteMachineryCard;
using WynajemMaszyn.Application.Features.Rollers.Queries.DTOs;
using WynajemMaszyn.Application.Features.Rollers.Queries.GetRollers;

namespace WynajemMaszyn.WebUI.Components.Pages.machines.Details
{
    partial class RollerDetails
    {
        private GetRollerDto machinery = new GetRollerDto();
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
            ImagePathList= machinery.ImagePath;
            CurrentImage = ImagePathList[0];
        }


        private async void AddMachineToCard()
        {
            var command = new AddMachineryCardCommand(
                        (int)IdMachine,
                        "Roller"
                       );
            var response = await Mediator.Send(command);

        }

        private async void DeleteMachineToCard()
        {
            var command = new DeleteMachineryCardCommand(
                        (int)IdMachine,
                        "Roller"
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
