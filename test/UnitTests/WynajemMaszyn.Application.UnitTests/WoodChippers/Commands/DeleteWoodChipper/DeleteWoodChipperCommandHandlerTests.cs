using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Security.Claims;
using WynajemMaszyn.Application.Features.WoodChippers.Command.DeleteWoodChippers;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.WoodChippers.TestUtils;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.UnitTests.WoodChippers.Commands.DeleteWoodChipper
{
    public class DeleteWoodChipperCommandHandlerTests
    {
        private readonly DeleteWoodChipperCommandHandler _handler;
        private readonly Mock<IWoodChipperRepository> _mockDeleteWoodChipperCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<UserManager<User>> _mockUserManager;

        public DeleteWoodChipperCommandHandlerTests()
        {
            _mockDeleteWoodChipperCommandHandler = new Mock<IWoodChipperRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockUserManager = new Mock<UserManager<User>>();
            _handler = new DeleteWoodChipperCommandHandler(_mockDeleteWoodChipperCommandHandler.Object, _mockUserManager.Object, _mockMachineryRepositoryHandler.Object);

        }


        [Fact]
        public async Task Handle_Should_ReturnErrorDeleteWoodChipper_WhenIsNotValue()
        {
            //arange
            var deleteWoodChipperCommand = DeleteWoodChipperCommandUtils.DeleteWoodChipperCommand();

_mockUserManager.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>()))
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

_mockUserManager.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>()))
                .Returns("1");

            //act
            var result = await _handler.Handle(deleteWoodChipperCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }
    }
}
