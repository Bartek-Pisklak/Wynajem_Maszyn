using Microsoft.AspNetCore.Components.Forms;
using WynajemMaszyn.Application.Features.Rollers.Command.CreateRollers;
using WynajemMaszyn.Application.Features.Rollers.Command.EditRollers;
using WynajemMaszyn.Application.Features.Rollers.Queries.DTOs;

namespace WynajemMaszyn.WebUI.Pages.Form
{
    public partial class RollerForm
    {
        private GetRollerDto rollertable = new GetRollerDto();
        private IBrowserFile? uploadedFile;
        private string action = "add";

        private async Task HandleImageUpload(InputFileChangeEventArgs e)
        {
            uploadedFile = e.File;
            // Logika do zapisu pliku, np. do folderu lub bazy danych
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
            var command = new CreateRollerCommand(
            rollertable.Name,
            rollertable.ProductionYear,
            rollertable.OperatingHours,
            rollertable.Weight,
            rollertable.Engine,
            rollertable.EnginePower,
            rollertable.DrivingSpeed,
            rollertable.FuelConsumption,
            rollertable.FuelType,
            rollertable.Gearbox,
            rollertable.NumberOfDrums,
            rollertable.RollerType,
            rollertable.DrumWidth,
            rollertable.MaxCompactionForce,
            rollertable.IsVibratory,
            rollertable.KnigeAsfalt,
            rollertable.RentalPricePerDay,
            rollertable.ImagePath,
            rollertable.Description
        );
            await Mediator.Send(command);

        }

        private async void EditRoller()
        {
            var command = new EditRollerCommand(
                    rollertable.Id,
                    rollertable.Name,
                    rollertable.ProductionYear,
                    rollertable.OperatingHours,
                    rollertable.Weight,
                    rollertable.Engine,
                    rollertable.EnginePower,
                    rollertable.DrivingSpeed,
                    rollertable.FuelConsumption,
                    rollertable.FuelType,
                    rollertable.Gearbox,
                    rollertable.NumberOfDrums,
                    rollertable.RollerType,
                    rollertable.DrumWidth,
                    rollertable.MaxCompactionForce,
                    rollertable.IsVibratory,
                    rollertable.KnigeAsfalt,
                    rollertable.RentalPricePerDay,
                    rollertable.ImagePath,
                    rollertable.Description,
                    rollertable.IsRepair
            );
            await Mediator.Send(command);
        }
    }
}
