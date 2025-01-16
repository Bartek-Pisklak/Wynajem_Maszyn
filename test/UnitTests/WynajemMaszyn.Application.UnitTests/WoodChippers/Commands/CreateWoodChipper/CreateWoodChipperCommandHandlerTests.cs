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
        private readonly Mock<UserManager<User>> _mockUserManager;

        public CreateWoodChipperCommandHandlerTests()
        {
            _mockCreateWoodChipperCommandHandler = new Mock<IWoodChipperRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockUserManager = new Mock<UserManager<User>>();
            _handler = new CreateWoodChipperCommandHandler(_mockCreateWoodChipperCommandHandler.Object, _mockUserManager.Object, _mockMachineryRepositoryHandler.Object);

        }

        [Fact]
        public async Task Handle_Should_ReturnErrorCreateWoodChipper_WhenIsNotValue()
        {
            //arange
            var createWoodChipperCommand = CreateWoodChipperCommandUtils.CreateWoodChipperCommand();

_mockUserManager.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>()))
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

_mockUserManager.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>()))
                .Returns("1");

            //act
            var result = await _handler.Handle(createWoodChipperCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }


    }
}
