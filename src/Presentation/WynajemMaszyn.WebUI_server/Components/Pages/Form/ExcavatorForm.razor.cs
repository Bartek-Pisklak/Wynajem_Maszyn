using WynajemMaszyn.Application.Features.Excavators.Command.CreateExcavators;
using WynajemMaszyn.Application.Features.Excavators.Queries.DTOs;
using WynajemMaszyn.Application.Features.Enums;
using WynajemMaszyn.Application.Features.Excavators.Command.EditExcavators;
using Microsoft.AspNetCore.Components.Forms;
using WynajemMaszyn.Application.Features.Excavators.Queries.GetExcavators;
using WynajemMaszyn.Domain.Entities;


namespace WynajemMaszyn.WebUI_server.Components.Pages.Form
{
    public partial class ExcavatorForm
    {
        private GetExcavatorDto machinery = new GetExcavatorDto();
        private IBrowserFile? uploadedFile;
        private FileUploud fileUploud = new FileUploud();

        private string action = "add";
        private string uploadedFileEdit;
        private int idMachine = 1;

        private readonly List<string> listTypeExcavator = new List<string>();
        private readonly List<string> listTypeChassis = new List<string>();
        private readonly List<string> listFuelType = new List<string>();


        protected override async Task OnInitializedAsync()
        {
            EnumsCustomer enumsCustomer = new EnumsCustomer();
            listTypeExcavator.Clear();
            listTypeExcavator.AddRange(enumsCustomer.GetTypeExcavator());

            listTypeChassis.Clear();
            listTypeChassis.AddRange(enumsCustomer.GetTypeChassis());

            listFuelType.Clear();
            listFuelType.AddRange(enumsCustomer.GetFuelType());


            if (action == "edit")
            {
                var command = new GetExcavatorQuery(
                            idMachine
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
            if (action == "add")
            {
                CreateRoller();
            }
            else if (action == "edit")
            {
                EditRoller();
            }
        }
        private async Task HandleImageUpload(InputFileChangeEventArgs e)
        {
            uploadedFile = e.File;
        }

        private async void CreateRoller()
        {
            FileUploud fileUploud = new FileUploud();


            var path = await fileUploud.CreatePathToImage(uploadedFile);
            if (path != null)
            {
                machinery.ImagePath = path;
            }

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
                    machinery.ImagePath,
                    machinery.Description
            );
            await Mediator.Send(command);
            navigationManager.NavigateTo("/RollerExcavator");
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
            navigationManager.NavigateTo("/RollerExcavator");
        }
    }
}
