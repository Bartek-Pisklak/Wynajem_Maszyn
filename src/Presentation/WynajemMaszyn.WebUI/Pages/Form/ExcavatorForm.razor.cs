using WynajemMaszyn.Application.Features.Excavators.Command.CreateExcavators;
using WynajemMaszyn.Application.Features.Excavators.Queries.DTOs;

namespace WynajemMaszyn.WebUI.Pages.Form
{
    public partial class ExcavatorForm
    {
        private GetExcavatorDto machinery = new GetExcavatorDto();

        private async void HandleValidSubmit()
        {
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
        }
    }
}
