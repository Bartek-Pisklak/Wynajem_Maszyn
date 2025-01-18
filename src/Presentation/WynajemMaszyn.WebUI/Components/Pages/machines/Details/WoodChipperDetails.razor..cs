﻿using Microsoft.AspNetCore.Components;
using WynajemMaszyn.Application.Features.WoodChippers.Queries.DTOs;
using WynajemMaszyn.Application.Features.WoodChippers.Queries.GetWoodChippers;

namespace WynajemMaszyn.WebUI.Components.Pages.machines.Details
{
    partial class WoodChipperDetails
    {
        private GetWoodChipperDto machinery = new GetWoodChipperDto();
        private List<string> ImagePathList = new();
        private string CurrentImage { get; set; } = string.Empty;
        private bool IsLightboxVisible { get; set; } = false;

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
            ImagePathList= machinery.ImagePath;
            CurrentImage = ImagePathList[0];
        }


        private void AddMachineToCard()
        {


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
