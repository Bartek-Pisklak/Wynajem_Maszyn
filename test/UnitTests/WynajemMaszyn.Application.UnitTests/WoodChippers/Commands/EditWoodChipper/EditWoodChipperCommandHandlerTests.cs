using FluentAssertions;
using Moq;
using WynajemMaszyn.Application.Features.WoodChippers.Command.EditWoodChippers;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.WoodChippers.TestUtils;

namespace WynajemMaszyn.Application.UnitTests.WoodChippers.Commands.EditWoodChipper
{
    public class EditWoodChipperCommandHandlerTests
    {
        private readonly EditWoodChipperCommandHandler _handler;
        private readonly Mock<IWoodChipperRepository> _mockEditWoodChipperCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<IUserContextGetIdService> _mockIUserContextGetIdService;


        public EditWoodChipperCommandHandlerTests()
        {
            _mockEditWoodChipperCommandHandler = new Mock<IWoodChipperRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockIUserContextGetIdService = new Mock<IUserContextGetIdService>();
            _handler = new EditWoodChipperCommandHandler(_mockEditWoodChipperCommandHandler.Object, _mockIUserContextGetIdService.Object, _mockMachineryRepositoryHandler.Object);

        }

        [Fact]
        public async Task Handle_Should_ReturnErrorEditWoodChipper_WhenIsNotValue()
        {
            //arange
            var editWoodChipperCommand = EditWoodChipperCommandUtils.EditWoodChipperCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
                .Returns(value: null);

            //act
            var result = await _handler.Handle(editWoodChipperCommand, default);

            //Assert
            result.IsError.Should().BeTrue();

        }


        [Fact]
        public async Task Handle_Should_ReturnEditWoodChipper_WhenIsValue()
        {
            //arange
            var editWoodChipperCommand = EditWoodChipperCommandUtils.EditWoodChipperCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
                .Returns(1);

            //act
            var result = await _handler.Handle(editWoodChipperCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }
    }
}
