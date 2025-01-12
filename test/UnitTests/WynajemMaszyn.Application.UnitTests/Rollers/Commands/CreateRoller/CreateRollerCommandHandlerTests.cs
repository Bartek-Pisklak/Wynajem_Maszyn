using FluentAssertions;
using Moq;
using WynajemMaszyn.Application.Features.Rollers.Command.CreateRollers;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.Rollers.TestUtils;

namespace WynajemMaszyn.Application.UnitTests.Rollers.Commands.CreateRoller
{
    public class CreateRollerCommandHandlerTests
    {
        private readonly CreateRollerCommandHandler _handler;
        private readonly Mock<IRollerRepository> _mockCreateRollerCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<IUserContextGetIdService> _mockIUserContextGetIdService;


        public CreateRollerCommandHandlerTests() 
        {
            _mockCreateRollerCommandHandler = new Mock<IRollerRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockIUserContextGetIdService = new Mock<IUserContextGetIdService>();
            _handler = new CreateRollerCommandHandler(_mockCreateRollerCommandHandler.Object, _mockIUserContextGetIdService.Object, _mockMachineryRepositoryHandler.Object);
        }


        [Fact]
        public async Task Handle_Should_ReturnErrorCreateRoller_WhenIsNotValue()
        {
            //arange
            var createRollerCommand = CreateRollerCommandUtils.CreateRollerCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
                .Returns(value: null);

            //act
            var result = await _handler.Handle(createRollerCommand, default);

            //Assert
            result.IsError.Should().BeTrue();

        }

        [Fact]
        public async Task Handle_Should_ReturnCreateRoller_WhenIsValue()
        {
            //arange
            var createRollerCommand = CreateRollerCommandUtils.CreateRollerCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
                .Returns("1");

            //act
            var result = await _handler.Handle(createRollerCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }
    }
}
