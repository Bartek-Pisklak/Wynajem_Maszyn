using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Security.Claims;
using WynajemMaszyn.Application.Features.Rollers.Command.CreateRollers;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.Rollers.TestUtils;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.UnitTests.Rollers.Commands.CreateRoller
{
    public class CreateRollerCommandHandlerTests
    {
        private readonly CreateRollerCommandHandler _handler;
        private readonly Mock<IRollerRepository> _mockCreateRollerCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<UserManager<User>> _mockUserManager;


        public CreateRollerCommandHandlerTests() 
        {
            _mockCreateRollerCommandHandler = new Mock<IRollerRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockUserManager = new Mock<UserManager<User>>();
            _handler = new CreateRollerCommandHandler(_mockCreateRollerCommandHandler.Object, _mockUserManager.Object, _mockMachineryRepositoryHandler.Object);
        }


        [Fact]
        public async Task Handle_Should_ReturnErrorCreateRoller_WhenIsNotValue()
        {
            //arange
            var createRollerCommand = CreateRollerCommandUtils.CreateRollerCommand();

_mockUserManager.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>()))
                .Returns(value: null);

            //act
            var result = await _handler.Handle(createRollerCommand, default);

            //Assert
            result.IsError.Should().BeTrue();

        }

        [Fact]
        public async Task Handle_Should_ReturnCreateRoller_WhenIsValue()
        {
            //arange
            var createRollerCommand = CreateRollerCommandUtils.CreateRollerCommand();

_mockUserManager.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>()))
                .Returns("1");

            //act
            var result = await _handler.Handle(createRollerCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }
    }
}
