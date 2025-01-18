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
        private readonly Mock<ICurrentUserService> _mockUserService;

        public DeleteRollerCommandHandlerTests()
        {
            _mockDeleteRollerCommandHandler = new Mock<IRollerRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockUserService = new Mock<ICurrentUserService>();
            _handler = new DeleteRollerCommandHandler(_mockDeleteRollerCommandHandler.Object, _mockMachineryRepositoryHandler.Object, _mockUserService.Object);


        }
        [Fact]
        public async Task Handle_Should_ReturnErrorDeleteRoller_WhenIsNotValue()
        {
            //arange
            var deleteRollerCommand = DeleteRollerCommandUtils.DeleteRollerCommand();

            //_mockUserService.userId


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


            //act
            var result = await _handler.Handle(deleteRollerCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }
    }

}
