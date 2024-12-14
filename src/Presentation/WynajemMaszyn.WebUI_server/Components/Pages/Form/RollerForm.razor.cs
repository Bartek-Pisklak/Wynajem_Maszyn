using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.IO;
using WynajemMaszyn.Application.Features.Enums;
using WynajemMaszyn.Application.Features.Excavators.Queries.GetExcavators;
using WynajemMaszyn.Application.Features.Rollers.Command.CreateRollers;
using WynajemMaszyn.Application.Features.Rollers.Command.EditRollers;
using WynajemMaszyn.Application.Features.Rollers.Queries.DTOs;
using WynajemMaszyn.Application.Features.Rollers.Queries.GetRollers;


namespace WynajemMaszyn.WebUI_server.Components.Pages.Form
{
    public partial class RollerForm
    {
        private GetRollerDto machinery = new GetRollerDto();
        private IBrowserFile? uploadedFile;
        private FileUploud fileUploud = new FileUploud();

        private string action = "add";
        private readonly int idMachine = 1;
        private string uploadedFileEdit;

        private readonly List<string> listTypeRoller = new List<string>();
        private readonly List<string> listFuelType = new List<string>();


        protected override async Task OnInitializedAsync()
        {
            EnumsCustomer enumsCustomer = new EnumsCustomer();
            listTypeRoller.Clear();
            listTypeRoller.AddRange(enumsCustomer.GetTypeRoller());
            listFuelType.Clear();
            listFuelType.AddRange(enumsCustomer.GetFuelType());


            if (action == "edit")
            {
                var command = new GetRollerQuery(
                            idMachine
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
                uploadedFileEdit = machinery.ImagePath;
            }

        }

        private async Task HandleImageUpload(InputFileChangeEventArgs e)
        {
            uploadedFile = e.File;
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


        private async void CreateRoller()
        {


            var path = await fileUploud.CreatePathToImage(uploadedFile);
            if(path != null)
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
            if(uploadedFileEdit != machinery.ImagePath)
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
