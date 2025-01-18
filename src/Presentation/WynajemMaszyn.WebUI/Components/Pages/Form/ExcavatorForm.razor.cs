using WynajemMaszyn.Application.Features.Excavators.Command.CreateExcavators;
using WynajemMaszyn.Application.Features.Excavators.Queries.DTOs;
using WynajemMaszyn.Application.Features.Enums;
using WynajemMaszyn.Application.Features.Excavators.Command.EditExcavators;
using Microsoft.AspNetCore.Components.Forms;
using WynajemMaszyn.Application.Features.Excavators.Queries.GetExcavators;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;

namespace WynajemMaszyn.WebUI.Components.Pages.Form
{
    public partial class ExcavatorForm
    {
        private GetExcavatorDto machinery = new GetExcavatorDto();
        private FileUploud fileUploud = new FileUploud();
        private List<string> validationErrors = new();
        private List<string> ImagePaths = new();

        [Parameter]
        [SupplyParameterFromQuery]
        public int? IdMachine { get; set; }

        [Parameter]
        [SupplyParameterFromQuery]
        public string? Action { get; set; }


        private readonly List<string> listTypeExcavator = new List<string>();
        private readonly List<string> listTypeChassis = new List<string>();
        private readonly List<string> listFuelType = new List<string>();


        protected override void OnParametersSet()
        {
            Action ??= "add";
        }

        protected override async Task OnInitializedAsync()
        {

            EnumsCustomer enumsCustomer = new EnumsCustomer();
            listTypeExcavator.Clear();
            listTypeExcavator.AddRange(enumsCustomer.GetTypeExcavator());

            listTypeChassis.Clear();
            listTypeChassis.AddRange(enumsCustomer.GetTypeChassis());

            listFuelType.Clear();
            listFuelType.AddRange(enumsCustomer.GetFuelType());


            if (Action == "edit")
            {
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

                machinery = excavator;
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
                    CreateRoller();
                }
                else if (Action == "edit")
                {
                    EditRoller();
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


        private async void CreateRoller()
        {
            string imagePaths = "";
            foreach (var i in ImagePaths)
            {
                imagePaths+= i;
                imagePaths+= ",";
            }
            imagePaths = imagePaths.Substring(0, imagePaths.Length - 1);

            var command = new CreateExcavatorCommand(
                    machinery.Name,
                    machinery.TypeExcavator,
                    machinery.TypeChassis,
                    machinery.RentalPricePerDay,
                    machinery.ProductionYear,
                    machinery.OperatingHours,
                    machinery.Weight,
                    machinery.Engine,
                    machinery.EnginePower,
                    machinery.DrivingSpeed,
                    machinery.FuelConsumption,
                    machinery.FuelType,
                    machinery.Gearbox,
                    machinery.MaxDiggingDepth,
                    imagePaths,
                    machinery.Description
            );

            await Mediator.Send(command);
            navigationManager.NavigateTo("/ExcavatorWorker");
        }

        private async void EditRoller()
        {
            string imagePaths = "";
            foreach (var i in ImagePaths)
            {
                imagePaths+= i;
                imagePaths+= ",";
            }
            imagePaths = imagePaths.Substring(0, imagePaths.Length - 1);

            var command = new EditExcavatorCommand(
                    machinery.Id,
                    machinery.Name,
                    machinery.TypeExcavator,
                    machinery.TypeChassis,
                    machinery.RentalPricePerDay,
                    machinery.ProductionYear,
                    machinery.OperatingHours,
                    machinery.Weight,
                    machinery.Engine,
                    machinery.EnginePower,
                    machinery.DrivingSpeed,
                    machinery.FuelConsumption,
                    machinery.FuelType,
                    machinery.Gearbox,
                    machinery.MaxDiggingDepth,
                    imagePaths,
                    machinery.Description,
                    machinery.IsRepair
            );
            await Mediator.Send(command);
            navigationManager.NavigateTo("/ExcavatorWorker");
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
