using FluentAssertions;
using Moq;
using WynajemMaszyn.Application.Features.Rollers.Command.DeleteRollers;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.Rollers.TestUtils;

namespace WynajemMaszyn.Application.UnitTests.Rollers.Commands.DeleteRoller
{
    public class DeleteRollerCommandHandlerTests
    {
        private readonly DeleteRollerCommandHandler _handler;
        private readonly Mock<IRollerRepository> _mockDeleteRollerCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<ICurrentUserService> _mockCurrentUserService;

        public DeleteRollerCommandHandlerTests()
        {
            _mockDeleteRollerCommandHandler = new Mock<IRollerRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockCurrentUserService = new Mock<ICurrentUserService>();
            _handler = new DeleteRollerCommandHandler(_mockDeleteRollerCommandHandler.Object, _mockMachineryRepositoryHandler.Object, _mockCurrentUserService.Object);


        }
        [Fact]
        public async Task Handle_Should_ReturnErrorDeleteRoller_WhenIsNotValue()
        {
            //arange
            var deleteRollerCommand = DeleteRollerCommandUtils.DeleteRollerCommand();

            _mockCurrentUserService.Setup(x => x.UserId)
            .Returns(value: null);
            //act
            var result = await _handler.Handle(deleteRollerCommand, default);

            //Assert
            result.IsError.Should().BeTrue();

        }

        [Fact]
        public async Task Handle_Should_ReturnDeleteRoller_WhenIsValue()
        {
            //arange
            var deleteRollerCommand = DeleteRollerCommandUtils.DeleteRollerCommand();

            _mockCurrentUserService.Setup(x => x.UserId)
            .Returns("1");

            _mockCurrentUserService.Setup(x => x.Roles)
            .Returns(new List<string> { "Worker" });
            //act
            var result = await _handler.Handle(deleteRollerCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }
    }

}
