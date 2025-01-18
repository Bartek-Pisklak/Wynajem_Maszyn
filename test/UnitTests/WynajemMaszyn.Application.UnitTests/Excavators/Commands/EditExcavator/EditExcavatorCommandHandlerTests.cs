﻿using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Security.Claims;
using WynajemMaszyn.Application.Features.Excavators.Command.EditExcavators;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.Excavators.TestUtils;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.UnitTests.Excavators.Commands.EditExcavator
{
    public class EditExcavatorCommandHandlerTests
    {
        private readonly EditExcavatorCommandHandler _handler;
        private readonly Mock<IExcavatorRepository> _mockEditExcavatorCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<ICurrentUserService> _mockUserService;


        public EditExcavatorCommandHandlerTests()
        {
            _mockEditExcavatorCommandHandler = new Mock<IExcavatorRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockUserService = new Mock<ICurrentUserService>();
           // _handler = new EditExcavatorCommandHandler(_mockEditExcavatorCommandHandler.Object, _mockUserManager.Object, _mockMachineryRepositoryHandler.Object);

        }

        [Fact]
        public async Task Handle_Should_ReturnErrorEditExcavator_WhenIsNotValue()
        {
            //arange
            var editExcavatorCommand = EditExcavatorCommandUtils.EditExcavatorCommand();


            //act
            var result = await _handler.Handle(editExcavatorCommand, default);

            //Assert
            result.IsError.Should().BeTrue();

        }


        [Fact]
        public async Task Handle_Should_ReturnEditExcavator_WhenIsValue()
        {
            //arange
            var editExcavatorCommand = EditExcavatorCommandUtils.EditExcavatorCommand();


            //act
            var result = await _handler.Handle(editExcavatorCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }

    }
}
