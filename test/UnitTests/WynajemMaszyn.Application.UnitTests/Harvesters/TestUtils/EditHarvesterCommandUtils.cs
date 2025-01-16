using WynajemMaszyn.Application.Features.Harvesters.Command.EditHarvesters;
using WynajemMaszyn.Application.UnitTests.TestUtils.Constants;


namespace WynajemMaszyn.Application.UnitTests.Harvesters.TestUtils
{
    public class EditHarvesterCommandUtils
    {
        public static EditHarvesterCommand EditHarvesterCommand() =>
                new EditHarvesterCommand(
                    Constants.Excavator.mockHttpContext.Object,
                Constants.Harvester.Id,
                Constants.Harvester.Name,
                Constants.Harvester.ProductionYear,
                Constants.Harvester.OperatingHours,
                Constants.Harvester.Weight,
                Constants.Harvester.Engine,
                Constants.Harvester.EnginePower,
                Constants.Harvester.DrivingSpeed,
                Constants.Harvester._FuelType,
                Constants.Harvester.FuelConsumption,
                Constants.Harvester.MaxSpeed,
                Constants.Harvester.CuttingDiameter,
                Constants.Harvester.MaxReach,
                Constants.Harvester._TypeChassis,
                Constants.Harvester.RentalPricePerDay,
                Constants.Harvester.ImagePath,
                Constants.Harvester.Description,
                Constants.Harvester.IsRepair
                    );
    }
}
