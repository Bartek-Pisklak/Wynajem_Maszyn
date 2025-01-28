using WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.CreateExcavatorBuckets;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.DTOs;
using WynajemMaszyn.Application.Features.Enums;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.EditExcavatorBuckets;
using Microsoft.AspNetCore.Components.Forms;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.GetExcavatorBuckets;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;

namespace WynajemMaszyn.WebUI.Components.Pages.Form
{
    public partial class ExcavatorBucketForm
    {
        [Parameter]
        [SupplyParameterFromQuery]
        public int? IdMachine { get; set; }

        [Parameter]
        [SupplyParameterFromQuery]
        public string? Action { get; set; }

        private GetExcavatorBucketDto machinery = new GetExcavatorBucketDto();
        private FileUploud fileUploud = new FileUploud();
        private List<string> validationErrors = new();
        private List<string> ImagePaths = new();


        protected override void OnParametersSet()
        {
            Action ??= "add";
        }

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

                machinery = ExcavatorBucket;
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

            if (machinery.Weight <= 0)
                validationErrors.Add("Waga musi być większa niż 0.");




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
                imagePaths += i;
                imagePaths += ",";
            }
            imagePaths = imagePaths.Substring(0, imagePaths.Length - 1);


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
                    imagePaths,
                    machinery.Description
            );

            await Mediator.Send(command);
            navigationManager.NavigateTo("/ExcavatorBucketWorker");
        }

        private async void EditRoller()
        {
            string imagePaths = "";
            foreach (var i in ImagePaths)
            {
                imagePaths += i;
                imagePaths += ",";
            }
            imagePaths = imagePaths.Substring(0, imagePaths.Length - 1);

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
                    imagePaths,
                    machinery.Description,
                    machinery.IsRepair
            );
            await Mediator.Send(command);
            navigationManager.NavigateTo("/ExcavatorBucketWorker");
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
