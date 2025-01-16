using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Security.Claims;
using WynajemMaszyn.Application.Features.Harvesters.Command.DeleteHarvesters;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.Harvesters.TestUtils;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.UnitTests.Harvesters.Commands.DeleteHarvester
{
    public class DeleteHarvesterCommandHandlerTests
    {
        private readonly DeleteHarvesterCommandHandler _handler;
        private readonly Mock<IHarvesterRepository> _mockDeleteHarvesterCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<UserManager<User>> _mockUserManager;

        public DeleteHarvesterCommandHandlerTests()
        {
            _mockDeleteHarvesterCommandHandler = new Mock<IHarvesterRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockUserManager = new Mock<UserManager<User>>();
            _handler = new DeleteHarvesterCommandHandler(_mockDeleteHarvesterCommandHandler.Object, _mockUserManager.Object, _mockMachineryRepositoryHandler.Object);

        }


        [Fact]
        public async Task Handle_Should_ReturnErrorDeleteHarvester_WhenIsNotValue()
        {
            //arange
            var deleteHarvesterCommand = DeleteHarvesterCommandUtils.DeleteHarvesterCommand();

_mockUserManager.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>()))
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

_mockUserManager.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>()))
                .Returns("1");

            //act
            var result = await _handler.Handle(deleteHarvesterCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }

    }
}
