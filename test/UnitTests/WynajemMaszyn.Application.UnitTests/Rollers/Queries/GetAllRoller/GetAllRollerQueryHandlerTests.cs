﻿using FluentAssertions;
using Moq;
using WynajemMaszyn.Application.Features.Rollers.Queries.GetAllRollers;
using WynajemMaszyn.Application.Persistance;

namespace WynajemMaszyn.Application.UnitTests.Rollers.Queries.GetAllRoller
{
    public class GetAllRollerQueryHandlerTests
    {
        private readonly GetAllRollerQueryHandler _handler;
        private readonly Mock<IRollerRepository> _mockGetAllRollerQueryHandler;

        public GetAllRollerQueryHandlerTests()
        {
            _mockGetAllRollerQueryHandler = new Mock<IRollerRepository>();
            _handler = new GetAllRollerQueryHandler(_mockGetAllRollerQueryHandler.Object);
        }

        [Fact]
        public async Task Handle_Should_ReturnErrorGetAllRoller_WhenIsNotValue()
        {
            //arange
            var getAllRollerQuery = new GetAllRollerQuery();


            _mockGetAllRollerQueryHandler.Setup(x => x.GetAllRoller())
            .ReturnsAsync(value: null);

            //act
            var result = await _handler.Handle(getAllRollerQuery, default);

            //Assert
            result.IsError.Should().BeTrue();

        }

        [Fact]
        public async Task Handle_Should_ReturnGetAllRoller_WhenIsValue()
        {
            //arange
            var getAllRollerQuery = new GetAllRollerQuery();

            // Act
            var result = await _handler.Handle(getAllRollerQuery, default);

            _mockGetAllRollerQueryHandler.Verify(x => x.GetAllRoller());

            //Assert
            result.IsError.Should().BeFalse();

        }


    }
}