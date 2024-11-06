using FluentAssertions;
using Moq;
using WynajemMaszyn.Application.Features.WoodChippers.Command.CreateWoodChippers;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.WoodChippers.TestUtils;

namespace WynajemMaszyn.Application.UnitTests.WoodChippers.Commands.CreateWoodChipper
{
    public class CreateWoodChipperCommandHandlerTests
    {
        private readonly CreateWoodChipperCommandHandler _handler;
        private readonly Mock<IWoodChipperRepository> _mockCreateWoodChipperCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<IUserContextGetIdService> _mockIUserContextGetIdService;

        public CreateWoodChipperCommandHandlerTests()
        {
            _mockCreateWoodChipperCommandHandler = new Mock<IWoodChipperRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockIUserContextGetIdService = new Mock<IUserContextGetIdService>();
            _handler = new CreateWoodChipperCommandHandler(_mockCreateWoodChipperCommandHandler.Object, _mockIUserContextGetIdService.Object, _mockMachineryRepositoryHandler.Object);

        }

        [Fact]
        public async Task Handle_Should_ReturnErrorCreateWoodChipper_WhenIsNotValue()
        {
            //arange
            var createWoodChipperCommand = CreateWoodChipperCommandUtils.CreateWoodChipperCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
                .Returns(value: null);

            //act
            var result = await _handler.Handle(createWoodChipperCommand, default);

            //Assert
            result.IsError.Should().BeTrue();

        }


        [Fact]
        public async Task Handle_Should_ReturnCreateWoodChipper_WhenIsValue()
        {
            //arange
            var createWoodChipperCommand = CreateWoodChipperCommandUtils.CreateWoodChipperCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
                .Returns(1);

            //act
            var result = await _handler.Handle(createWoodChipperCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }


    }
}
