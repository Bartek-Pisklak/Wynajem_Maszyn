using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Security.Claims;
using WynajemMaszyn.Application.Features.WoodChippers.Command.EditWoodChippers;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.WoodChippers.TestUtils;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.UnitTests.WoodChippers.Commands.EditWoodChipper
{
    public class EditWoodChipperCommandHandlerTests
    {
        private readonly EditWoodChipperCommandHandler _handler;
        private readonly Mock<IWoodChipperRepository> _mockEditWoodChipperCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<UserManager<User>> _mockUserManager;


        public EditWoodChipperCommandHandlerTests()
        {
            _mockEditWoodChipperCommandHandler = new Mock<IWoodChipperRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockUserManager = new Mock<UserManager<User>>();
            //_handler = new EditWoodChipperCommandHandler(_mockEditWoodChipperCommandHandler.Object, _mockUserManager.Object, _mockMachineryRepositoryHandler.Object);

        }

        [Fact]
        public async Task Handle_Should_ReturnErrorEditWoodChipper_WhenIsNotValue()
        {
            //arange
            var editWoodChipperCommand = EditWoodChipperCommandUtils.EditWoodChipperCommand();

                _mockUserManager.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>()))
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

                _mockUserManager.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>()))
                .Returns("1");

            //act
            var result = await _handler.Handle(editWoodChipperCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }
    }
}
