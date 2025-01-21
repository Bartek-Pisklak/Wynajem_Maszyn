using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Security.Claims;
using WynajemMaszyn.Application.Features.WoodChippers.Command.CreateWoodChippers;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.WoodChippers.TestUtils;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.UnitTests.WoodChippers.Commands.CreateWoodChipper
{
    public class CreateWoodChipperCommandHandlerTests
    {
        private readonly CreateWoodChipperCommandHandler _handler;
        private readonly Mock<IWoodChipperRepository> _mockCreateWoodChipperCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<ICurrentUserService> _mockCurrentUserService;

        public CreateWoodChipperCommandHandlerTests()
        {
            _mockCreateWoodChipperCommandHandler = new Mock<IWoodChipperRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockCurrentUserService = new Mock<ICurrentUserService>();
            _handler = new CreateWoodChipperCommandHandler(_mockCreateWoodChipperCommandHandler.Object, _mockMachineryRepositoryHandler.Object, _mockCurrentUserService.Object);

        }

        [Fact]
        public async Task Handle_Should_ReturnErrorCreateWoodChipper_WhenIsNotValue()
        {
            //arange
            var createWoodChipperCommand = CreateWoodChipperCommandUtils.CreateWoodChipperCommand();

            _mockCurrentUserService.Setup(x => x.UserId)
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

            _mockCurrentUserService.Setup(x => x.UserId)
            .Returns("1");

            _mockCurrentUserService.Setup(x => x.Roles)
            .Returns(new List<string> { "Worker" });

            //act
            var result = await _handler.Handle(createWoodChipperCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }


    }
}
