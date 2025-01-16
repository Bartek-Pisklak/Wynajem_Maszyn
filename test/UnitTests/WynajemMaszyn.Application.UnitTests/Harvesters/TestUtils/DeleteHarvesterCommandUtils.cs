
using WynajemMaszyn.Application.Features.Harvesters.Command.DeleteHarvesters;
using WynajemMaszyn.Application.UnitTests.TestUtils.Constants;


namespace WynajemMaszyn.Application.UnitTests.Harvesters.TestUtils
{
    public class DeleteHarvesterCommandUtils
    {
        public static DeleteHarvesterCommand DeleteHarvesterCommand() =>
                new DeleteHarvesterCommand(
                    Constants.Excavator.mockHttpContext.Object,
                    Constants.Harvester.Id
                    );

    }
}
