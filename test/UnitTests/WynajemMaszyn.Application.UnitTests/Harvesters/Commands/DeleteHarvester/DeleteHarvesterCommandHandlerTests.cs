using FluentAssertions;
using Moq;
using WynajemMaszyn.Application.Features.Harvesters.Command.DeleteHarvesters;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.Harvesters.TestUtils;

namespace WynajemMaszyn.Application.UnitTests.Harvesters.Commands.DeleteHarvester
{
    public class DeleteHarvesterCommandHandlerTests
    {
        private readonly DeleteHarvesterCommandHandler _handler;
        private readonly Mock<IHarvesterRepository> _mockDeleteHarvesterCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<IUserContextGetIdService> _mockIUserContextGetIdService;

        public DeleteHarvesterCommandHandlerTests()
        {
            _mockDeleteHarvesterCommandHandler = new Mock<IHarvesterRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockIUserContextGetIdService = new Mock<IUserContextGetIdService>();
            _handler = new DeleteHarvesterCommandHandler(_mockDeleteHarvesterCommandHandler.Object, _mockIUserContextGetIdService.Object, _mockMachineryRepositoryHandler.Object);

        }


        [Fact]
        public async Task Handle_Should_ReturnErrorDeleteHarvester_WhenIsNotValue()
        {
            //arange
            var deleteHarvesterCommand = DeleteHarvesterCommandUtils.DeleteHarvesterCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
                .Returns(value: null);

            //act
            var result = await _handler.Handle(deleteHarvesterCommand, default);

            //Assert
            result.IsError.Should().BeTrue();

        }


        [Fact]
        public async Task Handle_Should_ReturnDeleteHarvester_WhenIsValue()
        {
            //arange
            var deleteHarvesterCommand = DeleteHarvesterCommandUtils.DeleteHarvesterCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
                .Returns("1");

            //act
            var result = await _handler.Handle(deleteHarvesterCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }

    }
}
