using WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.CreateExcavatorBuckets;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.DTOs;
using WynajemMaszyn.Application.Features.Enums;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.EditExcavatorBuckets;
using Microsoft.AspNetCore.Components.Forms;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.GetExcavatorBuckets;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;


namespace WynajemMaszyn.WebUI_server.Components.Pages.Form
{
    public partial class ExcavatorBucketForm
    {
        private GetExcavatorBucketDto machinery = new GetExcavatorBucketDto();
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



        protected override async Task OnInitializedAsync()
        {
            EnumsCustomer enumsCustomer = new EnumsCustomer();



            if (Action == "edit")
            {
                if (IdMachine is null)
                {
                    navigationManager.NavigateTo("/ExcavatorBucketWorker");
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

                machinery=ExcavatorBucket;
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

            if (machinery.Weight <= 0)
                validationErrors.Add("Waga musi być większa niż 0.");




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
            var command = new CreateExcavatorBucketCommand(
                    machinery.Name,
                    machinery.BucketType,
                    machinery.ProductionYear,
                    machinery.BucketCapacity,
                    machinery.Weight,
                    machinery.Width,
                    machinery.PinDiameter,
                    machinery.ArmWidth,
                    machinery.PinSpacing,
                    machinery.Material,
                    machinery.MaxLoadCapacity,
                    machinery.RentalPricePerDay,
                    machinery.ImagePath,
                    machinery.Description
            );

            await Mediator.Send(command);
            navigationManager.NavigateTo("/ExcavatorBucketWorker");
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

            var command = new EditExcavatorBucketCommand(
                    machinery.Id,
                    machinery.Name,
                    machinery.BucketType,
                    machinery.ProductionYear,
                    machinery.BucketCapacity,
                    machinery.Weight,
                    machinery.Width,
                    machinery.PinDiameter,
                    machinery.ArmWidth,
                    machinery.PinSpacing,
                    machinery.Material,
                    machinery.MaxLoadCapacity,
                    machinery.RentalPricePerDay,
                    machinery.ImagePath,
                    machinery.Description,
                    machinery.IsRepair
            );
            await Mediator.Send(command);
            navigationManager.NavigateTo("/ExcavatorBucketWorker");
        }
    }
}
