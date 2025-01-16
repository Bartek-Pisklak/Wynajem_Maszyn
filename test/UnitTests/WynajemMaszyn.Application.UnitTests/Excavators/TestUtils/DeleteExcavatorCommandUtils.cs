using Moq;
using FluentAssertions;
using WynajemMaszyn.Application.Features.Excavators.Command.EditExcavators;
using WynajemMaszyn.Application.UnitTests.TestUtils.Constants;
using WynajemMaszyn.Application.Features.Excavators.Command.DeleteExcavators;

namespace WynajemMaszyn.Application.UnitTests.Excavators.TestUtils
{
    public class DeleteExcavatorCommandUtils
    {
        public static DeleteExcavatorCommand DeleteExcavatorCommand() =>
        new DeleteExcavatorCommand(
            Constants.Excavator.mockHttpContext.Object,
            Constants.Excavator.Id
        );

    }
}
