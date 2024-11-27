using WynajemMaszyn.Application.Features.Excavators.Command.CreateExcavators;
using WynajemMaszyn.Application.Features.Excavators.Queries.DTOs;
using WynajemMaszyn.Application.Features.Enums;


namespace WynajemMaszyn.WebUI_server.Components.Pages.Form
{
    public partial class ExcavatorForm
    {
        private GetExcavatorDto machinery = new GetExcavatorDto();

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

        }


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
