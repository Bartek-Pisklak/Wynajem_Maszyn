using FluentAssertions;
using Moq;
using WynajemMaszyn.Application.Features.Rollers.Command.EditRollers;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.Rollers.TestUtils;

namespace WynajemMaszyn.Application.UnitTests.Rollers.Commands.EditRoller
{
    public class EditRollerCommandHandlerTests
    {
        private readonly EditRollerCommandHandler _handler;
        private readonly Mock<IRollerRepository> _mockEditRollerCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<ICurrentUserService> _mockCurrentUserService;


        public EditRollerCommandHandlerTests()
        {
            _mockEditRollerCommandHandler = new Mock<IRollerRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockCurrentUserService = new Mock<ICurrentUserService>();
            _handler = new EditRollerCommandHandler(_mockEditRollerCommandHandler.Object, _mockMachineryRepositoryHandler.Object, _mockCurrentUserService.Object);

        }


        [Fact]
        public async Task Handle_Should_ReturnErrorEditedRoller_WhenIsNotValue()
        {
            //arange
            var editedRollerCommand = EditRollerCommandUtils.EditRollerCommand();

            _mockCurrentUserService.Setup(x => x.UserId)
            .Returns(value: null);
            //act
            var result = await _handler.Handle(editedRollerCommand, default);

            //Assert
            result.IsError.Should().BeTrue();

        }

        [Fact]
        public async Task Handle_Should_ReturnEditedRoller_WhenIsValue()
        {
            //arange
            var editedRollerCommand = EditRollerCommandUtils.EditRollerCommand();

            _mockCurrentUserService.Setup(x => x.UserId)
            .Returns("1");

            _mockCurrentUserService.Setup(x => x.Roles)
                    .Returns(new List<string> { "Worker" });
            //act
            var result = await _handler.Handle(editedRollerCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }
    }
}
