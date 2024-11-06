using FluentAssertions;
using Moq;
using WynajemMaszyn.Application.Features.Excavators.Command.EditExcavators;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.Excavators.TestUtils;

namespace WynajemMaszyn.Application.UnitTests.Excavators.Commands.EditExcavator
{
    public class EditExcavatorCommandHandlerTests
    {
        private readonly EditExcavatorCommandHandler _handler;
        private readonly Mock<IExcavatorRepository> _mockEditExcavatorCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<IUserContextGetIdService> _mockIUserContextGetIdService;


        public EditExcavatorCommandHandlerTests()
        {
            _mockEditExcavatorCommandHandler = new Mock<IExcavatorRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockIUserContextGetIdService = new Mock<IUserContextGetIdService>();
            _handler = new EditExcavatorCommandHandler(_mockEditExcavatorCommandHandler.Object, _mockIUserContextGetIdService.Object, _mockMachineryRepositoryHandler.Object);

        }

        [Fact]
        public async Task Handle_Should_ReturnErrorEditExcavator_WhenIsNotValue()
        {
            //arange
            var editExcavatorCommand = EditExcavatorCommandUtils.EditExcavatorCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
                .Returns(value: null);

            //act
            var result = await _handler.Handle(editExcavatorCommand, default);

            //Assert
            result.IsError.Should().BeTrue();

        }


        [Fact]
        public async Task Handle_Should_ReturnEditExcavator_WhenIsValue()
        {
            //arange
            var editExcavatorCommand = EditExcavatorCommandUtils.EditExcavatorCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
                .Returns(1);

            //act
            var result = await _handler.Handle(editExcavatorCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }

    }
}
