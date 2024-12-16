﻿using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using WynajemMaszyn.Application.Features.WoodChippers.Queries.DTOs;
using WynajemMaszyn.Application.Features.WoodChippers.Command.CreateWoodChippers;
using WynajemMaszyn.Application.Features.WoodChippers.Command.EditWoodChippers;
using Microsoft.JSInterop;

namespace WynajemMaszyn.WebUI_server.Components.Pages.Form
{
    partial class WoodChipper
    {
        private GetWoodChipperDto machinery = new GetWoodChipperDto();
        private IBrowserFile? uploadedFile;
        private FileUploud fileUploud = new FileUploud();
        private List<string> validationErrors = new();

        [Parameter]
        [SupplyParameterFromQuery]
        public int? IdMachine { get; set; }

        [Parameter]
        [SupplyParameterFromQuery]
        public string? Action { get; set; }

        private string uploadedFileEdit;

        private readonly List<string> listTypeWoodChipper = new List<string>();
        private readonly List<string> listFuelType = new List<string>();



        private async Task HandleImageUpload(InputFileChangeEventArgs e)
        {
            uploadedFile = e.File;
        }



        private async void HandleValidSubmit()
        {
            validationErrors.Clear();

            if (string.IsNullOrWhiteSpace(machinery.Name))
                validationErrors.Add("Nazwa maszyny jest wymagana.");

            if (machinery.ProductionYear <= 0)
                validationErrors.Add("Rok produkcji musi być większy niż 0.");

            if (machinery.OperatingHours <= 0)
                validationErrors.Add("Liczba godzin pracy musi być większa niż 0.");

            if (machinery.Weight <= 0)
                validationErrors.Add("Waga musi być większa niż 0.");

            if (string.IsNullOrWhiteSpace(machinery.Engine))
                validationErrors.Add("Silnik jest wymagany.");

            if (machinery.EnginePower <= 0)
                validationErrors.Add("Moc silnika musi być większa niż 0.");

            if (machinery.DrivingSpeed <= 0)
                validationErrors.Add("Prędkość jazdy musi być większa niż 0.");

            if (uploadedFile is null)
                validationErrors.Add("Brak obrazu");

            if (validationErrors.Any())
            {
                foreach (var error in validationErrors)
                {
                    Console.WriteLine($"Błąd walidacji: {error}");

                }

                await Task.Run(() => {
                    // Wywołanie przewinięcia strony na początku w Blazor
                    var jsCode = "window.scrollTo({ top: 0, behavior: 'smooth' });";
                    JSRuntime.InvokeVoidAsync("eval", jsCode);
                });
                return;
            }
            else
            {
                if (Action == "add")
                {
                    CreateWoodChipper();
                }
                else if (Action == "edit")
                {
                    EditWoodChipper();
                }
            }
        }

        private async void CreateWoodChipper()
        {

            var path = await fileUploud.CreatePathToImage(uploadedFile);
            if (path != null)
            {
                machinery.ImagePath = path;
            }

            var command = new CreateWoodChipperCommand(
                machinery.Name,
                machinery.RentalPricePerDay,
                machinery.ProductionYear,
                machinery.OperatingHours,
                machinery.Weight,
                machinery.Engine,
                machinery.EnginePower,
                machinery.Gearbox,
                machinery.DrivingSpeed,
                machinery.FuelConsumption,
                machinery.FuelType,
                machinery.MachineLength,
                machinery.TransportHeight,
                machinery.ChoppingHeight,
                machinery.MachineWidth,
                machinery.FlowMaterial,
                machinery.ImagePath,
                machinery.Description
            );
            await Mediator.Send(command);
            navigationManager.NavigateTo("/WoodChipperWorker");
        }

        private async void EditWoodChipper()
        {
            if (uploadedFileEdit != machinery.ImagePath)
            {
                fileUploud.DeleteImage(uploadedFileEdit);
                var path = await fileUploud.CreatePathToImage(uploadedFile);
                if (path != null)
                {
                    machinery.ImagePath = path;
                }
            }

            var command = new EditWoodChipperCommand(
                machinery.Id,
                machinery.Name,
                machinery.RentalPricePerDay,
                machinery.ProductionYear,
                machinery.OperatingHours,
                machinery.Weight,
                machinery.Engine,
                machinery.EnginePower,
                machinery.Gearbox,
                machinery.DrivingSpeed,
                machinery.FuelConsumption,
                machinery.FuelType,
                machinery.MachineLength,
                machinery.TransportHeight,
                machinery.ChoppingHeight,
                machinery.MachineWidth,
                machinery.FlowMaterial,
                machinery.ImagePath,
                machinery.Description,
                machinery.IsRepair
            );
            await Mediator.Send(command);
            navigationManager.NavigateTo("/WoodChipperWorker");
        }
    }
}
