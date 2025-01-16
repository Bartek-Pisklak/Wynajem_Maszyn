﻿using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using WynajemMaszyn.Application.Features.Enums;
using WynajemMaszyn.Application.Features.Harvesters.Command.CreateHarvesters;
using WynajemMaszyn.Application.Features.Harvesters.Command.EditHarvesters;
using WynajemMaszyn.Application.Features.Harvesters.Queries.GetHarvesters;
using WynajemMaszyn.Application.Features.Harvesters.Queries.DTOs;
using Microsoft.AspNetCore.Components;

namespace WynajemMaszyn.WebUI.Components.Pages.Form
{
    partial class HarvesterForm
    {
        private GetHarvesterDto machinery = new GetHarvesterDto();
        private FileUploud fileUploud = new FileUploud();
        private List<string> validationErrors = new();
        private List<string> ImagePaths = new();

        [CascadingParameter]
        private HttpContext HttpContext { get; set; } = default!;

        [Parameter]
        [SupplyParameterFromQuery]
        public int? IdMachine { get; set; }

        [Parameter]
        [SupplyParameterFromQuery]
        public string? Action { get; set; }

        private string uploadedFileEdit;

        private readonly List<string> listTypeChassis = new List<string>();
        private readonly List<string> listFuelType = new List<string>();

        protected override void OnParametersSet()
        {
            Action ??= "add";
        }

        protected override async Task OnInitializedAsync()
        {
            HttpContext = HttpContextAccessor.HttpContext;
            EnumsCustomer enumsCustomer = new EnumsCustomer();

            listTypeChassis.Clear();
            listTypeChassis.AddRange(enumsCustomer.GetTypeChassis());

            listFuelType.Clear();
            listFuelType.AddRange(enumsCustomer.GetFuelType());


            if (Action == "edit")
            {
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

                machinery = Harvester;
                ImagePaths = machinery.ImagePath;
            }

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

            if (!ImagePaths.Any())
                validationErrors.Add("Brak obrazu");

            if (validationErrors.Any())
            {
                foreach (var error in validationErrors)
                {
                    Console.WriteLine($"Błąd walidacji: {error}");

                }

                await Task.Run(() =>
                {
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
                    CreateHarvester();
                }
                else if (Action == "edit")
                {
                    EditHarvester();
                }
            }
        }

        private async Task HandleImageUpload(InputFileChangeEventArgs e)
        {
            var files = e.GetMultipleFiles();

            foreach (var file in files)
            {
                if (file.Size > 5 * 1024 * 1024)
                {
                    validationErrors.Add($"Plik {file.Name} przekracza maksymalny rozmiar 5 MB.");
                    continue;
                }

                var path = await fileUploud.CreatePathToImage(file);
                if (!string.IsNullOrEmpty(path))
                {
                    ImagePaths.Add(path);
                }
                else
                {
                    validationErrors.Add($"Nie udało się przesłać pliku {file.Name}.");
                }

            }
        }


        private async void CreateHarvester()
        {
            string imagePaths = "";
            foreach (var i in ImagePaths)
            {
                imagePaths+= i;
                imagePaths+= ",";
            }
            imagePaths = imagePaths.Substring(0, imagePaths.Length - 1);

            var command = new CreateHarvesterCommand(
                HttpContext,
                    machinery.Name,
                    machinery.ProductionYear,
                    machinery.OperatingHours,
                    machinery.Weight,
                    machinery.Engine,
                    machinery.EnginePower,
                    machinery.DrivingSpeed,
                    machinery.FuelType,
                    machinery.FuelConsumption,
                    machinery.MaxSpeed,
                    machinery.CuttingDiameter,
                    machinery.MaxReach,
                    machinery.TypeChassis,
                    machinery.RentalPricePerDay,
                    imagePaths,
                    machinery.Description
            );

            await Mediator.Send(command);
            navigationManager.NavigateTo("/HarvesterWorker");
        }

        private async void EditHarvester()
        {
            string imagePaths = "";
            foreach (var i in ImagePaths)
            {
                imagePaths+= i;
                imagePaths+= ",";
            }
            imagePaths = imagePaths.Substring(0, imagePaths.Length - 1);

            var command = new EditHarvesterCommand(
                HttpContext,
                    machinery.Id,
                    machinery.Name,
                    machinery.ProductionYear,
                    machinery.OperatingHours,
                    machinery.Weight,
                    machinery.Engine,
                    machinery.EnginePower,
                    machinery.DrivingSpeed,
                    machinery.FuelType,
                    machinery.FuelConsumption,
                    machinery.MaxSpeed,
                    machinery.CuttingDiameter,
                    machinery.MaxReach,
                    machinery.TypeChassis,
                    machinery.RentalPricePerDay,
                    imagePaths,
                    machinery.Description,
                    machinery.IsRepair
            );
            await Mediator.Send(command);
            navigationManager.NavigateTo("/HarvesterWorker");
        }

        private void RemoveImage(string imagePath)
        {
            if (ImagePaths.Contains(imagePath))
            {
                ImagePaths.Remove(imagePath);

                fileUploud.DeleteImage(imagePath);
            }
        }
    }
}
