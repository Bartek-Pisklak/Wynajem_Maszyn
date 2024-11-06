using WynajemMaszyn.Application.UnitTests.TestUtils.Constants;
using WynajemMaszyn.Application.Features.WoodChippers.Command.EditWoodChippers;

namespace WynajemMaszyn.Application.UnitTests.WoodChippers.TestUtils
{
    public class EditWoodChipperCommandUtils
    {
        public static EditWoodChipperCommand EditWoodChipperCommand() =>
            new EditWoodChipperCommand(
                Constants.WoodChipper.Id,
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
