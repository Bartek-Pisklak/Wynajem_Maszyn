using WynajemMaszyn.Application.UnitTests.TestUtils.Constants;
using WynajemMaszyn.Application.Features.WoodChippers.Command.CreateWoodChippers;

namespace WynajemMaszyn.Application.UnitTests.WoodChippers.TestUtils
{
    public class CreateWoodChipperCommandUtils
    {
        public static CreateWoodChipperCommand CreateWoodChipperCommand() =>
            new CreateWoodChipperCommand(
                Constants.Excavator.mockHttpContext.Object,
                Constants.WoodChipper.Name,
                Constants.WoodChipper.RentalPricePerDay,
                Constants.WoodChipper.ProductionYear,
                Constants.WoodChipper.OperatingHours,
                Constants.WoodChipper.Weight,
                Constants.WoodChipper.Engine,
                Constants.WoodChipper.EnginePower,
                Constants.WoodChipper.Gearbox,
                Constants.WoodChipper.DrivingSpeed,
                Constants.WoodChipper.FuelConsumption,
                Constants.WoodChipper._FuelType,
                Constants.WoodChipper.MachineLength,
                Constants.WoodChipper.TransportHeight,
                Constants.WoodChipper.ChoppingHeight,
                Constants.WoodChipper.MachineWidth,
                Constants.WoodChipper.FlowMaterial,
                Constants.WoodChipper.ImagePath,
                Constants.WoodChipper.Description
                );
    }
}
