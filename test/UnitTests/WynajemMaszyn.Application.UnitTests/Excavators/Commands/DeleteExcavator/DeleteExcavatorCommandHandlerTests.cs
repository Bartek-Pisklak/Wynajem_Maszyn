using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Security.Claims;
using WynajemMaszyn.Application.Features.Excavators.Command.CreateExcavators;
using WynajemMaszyn.Application.Features.Excavators.Command.DeleteExcavators;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.Excavators.TestUtils;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.UnitTests.Excavators.Commands.DeleteExcavator
{
    public class DeleteExcavatorCommandHandlerTests
    {
        private readonly DeleteExcavatorCommandHandler _handler;
        private readonly Mock<IExcavatorRepository> _mockDeleteExcavatorCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<ICurrentUserService> _mockUserService;

        public DeleteExcavatorCommandHandlerTests()
        {
            _mockDeleteExcavatorCommandHandler = new Mock<IExcavatorRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockUserService = new Mock<ICurrentUserService>();
            //_handler = new DeleteExcavatorCommandHandler(_mockDeleteExcavatorCommandHandler.Object, _mockUserManager.Object, _mockMachineryRepositoryHandler.Object);

        }


        [Fact]
        public async Task Handle_Should_ReturnErrorDeleteExcavator_WhenIsNotValue()
        {
            //arange
            var deleteExcavatorCommand = DeleteExcavatorCommandUtils.DeleteExcavatorCommand();



            //act
            var result = await _handler.Handle(deleteExcavatorCommand, default);

            //Assert
            result.IsError.Should().BeTrue();

        }


        [Fact]
        public async Task Handle_Should_ReturnDeleteExcavator_WhenIsValue()
        {
            //arange
            var deleteExcavatorCommand = DeleteExcavatorCommandUtils.DeleteExcavatorCommand();


            //act
            var result = await _handler.Handle(deleteExcavatorCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }
    }
 
}
