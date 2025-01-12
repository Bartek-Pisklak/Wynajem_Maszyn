using FluentAssertions;
using Moq;
using WynajemMaszyn.Application.Features.WoodChippers.Command.DeleteWoodChippers;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.WoodChippers.TestUtils;

namespace WynajemMaszyn.Application.UnitTests.WoodChippers.Commands.DeleteWoodChipper
{
    public class DeleteWoodChipperCommandHandlerTests
    {
        private readonly DeleteWoodChipperCommandHandler _handler;
        private readonly Mock<IWoodChipperRepository> _mockDeleteWoodChipperCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<IUserContextGetIdService> _mockIUserContextGetIdService;

        public DeleteWoodChipperCommandHandlerTests()
        {
            _mockDeleteWoodChipperCommandHandler = new Mock<IWoodChipperRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockIUserContextGetIdService = new Mock<IUserContextGetIdService>();
            _handler = new DeleteWoodChipperCommandHandler(_mockDeleteWoodChipperCommandHandler.Object, _mockIUserContextGetIdService.Object, _mockMachineryRepositoryHandler.Object);

        }


        [Fact]
        public async Task Handle_Should_ReturnErrorDeleteWoodChipper_WhenIsNotValue()
        {
            //arange
            var deleteWoodChipperCommand = DeleteWoodChipperCommandUtils.DeleteWoodChipperCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
                .Returns(value: null);

            //act
            var result = await _handler.Handle(deleteWoodChipperCommand, default);

            //Assert
            result.IsError.Should().BeTrue();

        }


        [Fact]
        public async Task Handle_Should_ReturnDeleteWoodChipper_WhenIsValue()
        {
            //arange
            var deleteWoodChipperCommand = DeleteWoodChipperCommandUtils.DeleteWoodChipperCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
                .Returns("1");

            //act
            var result = await _handler.Handle(deleteWoodChipperCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }
    }
}
