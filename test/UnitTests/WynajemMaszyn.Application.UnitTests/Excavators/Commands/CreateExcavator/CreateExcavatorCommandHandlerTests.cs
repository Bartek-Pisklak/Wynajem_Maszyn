using Moq;
using FluentAssertions;
using WynajemMaszyn.Application.UnitTests.Excavators.TestUtils;
using WynajemMaszyn.Application.Features.Excavators.Command.CreateExcavators;
using WynajemMaszyn.Application.Persistance;


namespace WynajemMaszyn.Application.UnitTests.Excavators.Commands.CreateExcavator
{
    public class CreateExcavatorCommandHandlerTests
    {
        private readonly CreateExcavatorCommandHandler _handler;
        private readonly Mock<IExcavatorRepository> _mockCreateExcavatorCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<IUserContextGetIdService> _mockIUserContextGetIdService;


        public CreateExcavatorCommandHandlerTests() 
        {
            _mockCreateExcavatorCommandHandler = new Mock<IExcavatorRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockIUserContextGetIdService = new Mock<IUserContextGetIdService>();
            _handler = new CreateExcavatorCommandHandler(_mockCreateExcavatorCommandHandler.Object, _mockIUserContextGetIdService.Object,_mockMachineryRepositoryHandler.Object);


        }



        [Fact]
        public async Task Handle_Should_ReturnErrorCreateExcavator_WhenIsNotValue()
        {
            //arange
            var createExcavatorCommand = CreateExcavatorCommandUtils.CreateExcavatorCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
                .Returns(value: null);

            //act
            var result = await _handler.Handle(createExcavatorCommand, default);

            //Assert
            result.IsError.Should().BeTrue();

        }


        [Fact]
        public async Task Handle_Should_ReturnCreateExcavator_WhenIsValue()
        {
            //arange
            var createExcavatorCommand = CreateExcavatorCommandUtils.CreateExcavatorCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
                .Returns("1");

            //act
            var result = await _handler.Handle(createExcavatorCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }

    }
}
