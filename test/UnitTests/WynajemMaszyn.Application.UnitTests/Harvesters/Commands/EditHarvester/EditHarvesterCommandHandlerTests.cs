using Moq;
using FluentAssertions;
using WynajemMaszyn.Application.Features.Harvesters.Command.EditHarvesters;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.Harvesters.TestUtils;
using Microsoft.AspNetCore.Identity;
using WynajemMaszyn.Domain.Entities;
using System.Security.Claims;

namespace WynajemMaszyn.Application.UnitTests.Harvesters.Commands.EditHarvester
{
    public class EditHarvesterCommandHandlerTests
    {
        private readonly EditHarvesterCommandHandler _handler;
        private readonly Mock<IHarvesterRepository> _mockEditHarvesterCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<UserManager<User>> _mockUserManager;


        public EditHarvesterCommandHandlerTests()
        {
            _mockEditHarvesterCommandHandler = new Mock<IHarvesterRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockUserManager = new Mock<UserManager<User>>();
        //    _handler = new EditHarvesterCommandHandler(_mockEditHarvesterCommandHandler.Object, _mockUserManager.Object, _mockMachineryRepositoryHandler.Object);

        }

        [Fact]
        public async Task Handle_Should_ReturnErrorEditHarvester_WhenIsNotValue()
        {
            //arange
            var editHarvesterCommand = EditHarvesterCommandUtils.EditHarvesterCommand();

_mockUserManager.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>()))
                .Returns(value: null);

            //act
            var result = await _handler.Handle(editHarvesterCommand, default);

            //Assert
            result.IsError.Should().BeTrue();

        }


        [Fact]
        public async Task Handle_Should_ReturnEditHarvester_WhenIsValue()
        {
            //arange
            var editHarvesterCommand = EditHarvesterCommandUtils.EditHarvesterCommand();

_mockUserManager.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>()))
                .Returns("1");

            //act
            var result = await _handler.Handle(editHarvesterCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }

    }
}
