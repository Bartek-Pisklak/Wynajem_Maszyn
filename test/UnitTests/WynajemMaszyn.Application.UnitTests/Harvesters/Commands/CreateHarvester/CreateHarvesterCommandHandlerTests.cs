using FluentAssertions;
using Moq;
using WynajemMaszyn.Application.Features.Harvesters.Command.CreateHarvesters;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.Harvesters.TestUtils;

namespace WynajemMaszyn.Application.UnitTests.Harvesters.Commands.CreateHarvester
{
    public class CreateHarvesterCommandHandlerTests
    {
        private readonly CreateHarvesterCommandHandler _handler;
        private readonly Mock<IHarvesterRepository> _mockCreateHarvesterCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<IUserContextGetIdService> _mockIUserContextGetIdService;

        public CreateHarvesterCommandHandlerTests()
        {
            _mockCreateHarvesterCommandHandler = new Mock<IHarvesterRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockIUserContextGetIdService = new Mock<IUserContextGetIdService>();
            _handler = new CreateHarvesterCommandHandler(_mockCreateHarvesterCommandHandler.Object, _mockIUserContextGetIdService.Object, _mockMachineryRepositoryHandler.Object);

        }

        [Fact]
        public async Task Handle_Should_ReturnErrorCreateHarvester_WhenIsNotValue()
        {
            //arange
            var createHarvesterCommand = CreateHarvesterCommandUtils.CreateHarvesterCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
                .Returns(value: null);

            //act
            var result = await _handler.Handle(createHarvesterCommand, default);

            //Assert
            result.IsError.Should().BeTrue();

        }


        [Fact]
        public async Task Handle_Should_ReturnCreateHarvester_WhenIsValue()
        {
            //arange
            var createHarvesterCommand = CreateHarvesterCommandUtils.CreateHarvesterCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
                .Returns(1);

            //act
            var result = await _handler.Handle(createHarvesterCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }
    }
}
