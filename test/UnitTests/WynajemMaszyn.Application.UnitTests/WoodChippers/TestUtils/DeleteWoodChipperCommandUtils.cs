using WynajemMaszyn.Application.Features.WoodChippers.Command.DeleteWoodChippers;
using WynajemMaszyn.Application.UnitTests.TestUtils.Constants;


namespace WynajemMaszyn.Application.UnitTests.WoodChippers.TestUtils
{
    public class DeleteWoodChipperCommandUtils
    {
        public static DeleteWoodChipperCommand DeleteWoodChipperCommand() =>
            new DeleteWoodChipperCommand(
                Constants.Excavator.mockHttpContext.Object,
                Constants.WoodChipper.Id
                );
    }
}
