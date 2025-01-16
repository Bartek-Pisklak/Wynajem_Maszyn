using WynajemMaszyn.Application.Features.Excavators.Command.CreateExcavators;
using WynajemMaszyn.Application.Features.Excavators.Queries.DTOs;
using WynajemMaszyn.Application.Features.Enums;
using WynajemMaszyn.Application.Features.Excavators.Command.EditExcavators;
using Microsoft.AspNetCore.Components.Forms;
using WynajemMaszyn.Application.Features.Excavators.Queries.GetExcavators;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;


namespace WynajemMaszyn.WebUI_server.Components.Pages.Form
{
    public partial class ExcavatorForm
    {
        private GetExcavatorDto machinery = new GetExcavatorDto();
        private IBrowserFile? uploadedFile;
        private FileUploud fileUploud = new FileUploud();
        private List<string> validationErrors = new();

        [CascadingParameter]
        private HttpContext HttpContext { get; set; } = default!;
        [Parameter]
        [SupplyParameterFromQuery]
        public int? IdMachine { get; set; }

        [Parameter]
        [SupplyParameterFromQuery]
        public string? Action { get; set; }

        private string uploadedFileEdit;

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
                if(IdMachine is null)
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
                uploadedFileEdit = machinery.ImagePath;
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

            if (uploadedFile is null && uploadedFileEdit is null)
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
            uploadedFile = e.File;
            return;
        }

        private async void CreateRoller()
        {
            var path = await fileUploud.CreatePathToImage(uploadedFile);
            if (path != null)
            {
                machinery.ImagePath = path;
            }
            else
            {
                validationErrors.Add("Obraz jest za dużo niż 5MB lub zepsuty plik");
            }
            var command = new CreateExcavatorCommand(
                HttpContext,
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
                    machinery.ImagePath,
                    machinery.Description
            );

            await Mediator.Send(command);
            navigationManager.NavigateTo("/ExcavatorWorker");
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

            var command = new EditExcavatorCommand(
                HttpContext,
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
                    machinery.ImagePath,
                    machinery.Description,
                    machinery.IsRepair
            );
            await Mediator.Send(command);
            navigationManager.NavigateTo("/ExcavatorWorker");
        }
    }
}
