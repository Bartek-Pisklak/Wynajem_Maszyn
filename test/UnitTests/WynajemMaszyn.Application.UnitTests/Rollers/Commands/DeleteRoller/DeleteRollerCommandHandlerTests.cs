using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Security.Claims;
using WynajemMaszyn.Application.Features.Rollers.Command.DeleteRollers;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.Rollers.TestUtils;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.UnitTests.Rollers.Commands.DeleteRoller
{
    public class DeleteRollerCommandHandlerTests
    {
        private readonly DeleteRollerCommandHandler _handler;
        private readonly Mock<IRollerRepository> _mockDeleteRollerCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<UserManager<User>> _mockUserManager;

        public DeleteRollerCommandHandlerTests()
        {
            _mockDeleteRollerCommandHandler = new Mock<IRollerRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockUserManager = new Mock<UserManager<User>>();
            _handler = new DeleteRollerCommandHandler(_mockDeleteRollerCommandHandler.Object, _mockUserManager.Object, _mockMachineryRepositoryHandler.Object);


        }
        [Fact]
        public async Task Handle_Should_ReturnErrorDeleteRoller_WhenIsNotValue()
        {
            //arange
            var deleteRollerCommand = DeleteRollerCommandUtils.DeleteRollerCommand();

_mockUserManager.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>()))
                .Returns(value: null);

            //act
            var result = await _handler.Handle(deleteRollerCommand, default);

            //Assert
            result.IsError.Should().BeTrue();

        }

        [Fact]
        public async Task Handle_Should_ReturnDeleteRoller_WhenIsValue()
        {
            //arange
            var deleteRollerCommand = DeleteRollerCommandUtils.DeleteRollerCommand();

_mockUserManager.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>()))
                .Returns("1");

            //act
            var result = await _handler.Handle(deleteRollerCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }
    }

}
