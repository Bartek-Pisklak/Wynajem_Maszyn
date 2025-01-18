
using WynajemMaszyn.Application.Features.Rollers.Command.DeleteRollers;
using WynajemMaszyn.Application.UnitTests.TestUtils.Constants;

namespace WynajemMaszyn.Application.UnitTests.Rollers.TestUtils
{
    public class DeleteRollerCommandUtils
    {
        public static DeleteRollerCommand DeleteRollerCommand() =>
            new DeleteRollerCommand(
                Constants.Roller.Id
            );
    }
}
