using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using WynajemMaszyn.Application.Features.Enums;
using WynajemMaszyn.Application.Features.Rollers.Command.CreateRollers;
using WynajemMaszyn.Application.Features.Rollers.Command.EditRollers;
using WynajemMaszyn.Application.Features.Rollers.Queries.DTOs;
using WynajemMaszyn.Application.Features.Rollers.Queries.GetRollers;


namespace WynajemMaszyn.WebUI.Components.Pages.Form
{
    public partial class RollerForm
    {
        private GetRollerDto machinery = new GetRollerDto();
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

        private readonly List<string> listTypeRoller = new List<string>();
        private readonly List<string> listFuelType = new List<string>();

        protected override void OnParametersSet()
        {
            Action ??= "add";
        }

        protected override async Task OnInitializedAsync()
        {
            EnumsCustomer enumsCustomer = new EnumsCustomer();
            listTypeRoller.Clear();
            listTypeRoller.AddRange(enumsCustomer.GetTypeRoller());
            listFuelType.Clear();
            listFuelType.AddRange(enumsCustomer.GetFuelType());


            if (Action == "edit")
            {
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

                machinery = roller;
                uploadedFileEdit = machinery.ImagePath;
            }

        }

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

            if (uploadedFile is null && uploadedFileEdit is null)
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


        private async void CreateRoller()
        {





            var path = await fileUploud.CreatePathToImage(uploadedFile);
            if (path != null)
            {
                machinery.ImagePath = path;
            }

            var command = new CreateRollerCommand(
            machinery.Name,
            machinery.ProductionYear,
            machinery.OperatingHours,
            machinery.Weight,
            machinery.Engine,
            machinery.EnginePower,
            machinery.DrivingSpeed,
            machinery.FuelConsumption,
            machinery.FuelType,
            machinery.Gearbox,
            machinery.NumberOfDrums,
            machinery.RollerType,
            machinery.DrumWidth,
            machinery.MaxCompactionForce,
            machinery.IsVibratory,
            machinery.KnigeAsfalt,
            machinery.RentalPricePerDay,
            machinery.ImagePath,
            machinery.Description
            );
            await Mediator.Send(command);
            navigationManager.NavigateTo("/RollerWorker");
        }

        private async void EditRoller()
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

            var command = new EditRollerCommand(
                    machinery.Id,
                    machinery.Name,
                    machinery.ProductionYear,
                    machinery.OperatingHours,
                    machinery.Weight,
                    machinery.Engine,
                    machinery.EnginePower,
                    machinery.DrivingSpeed,
                    machinery.FuelConsumption,
                    machinery.FuelType,
                    machinery.Gearbox,
                    machinery.NumberOfDrums,
                    machinery.RollerType,
                    machinery.DrumWidth,
                    machinery.MaxCompactionForce,
                    machinery.IsVibratory,
                    machinery.KnigeAsfalt,
                    machinery.RentalPricePerDay,
                    machinery.ImagePath,
                    machinery.Description,
                    machinery.IsRepair
            );
            await Mediator.Send(command);
            navigationManager.NavigateTo("/RollerWorker");
        }
    }
}
