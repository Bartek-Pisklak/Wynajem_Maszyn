using Moq;
using FluentAssertions;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.CreateExcavatorBuckets;
using WynajemMaszyn.Application.UnitTests.ExcavatorBuckets.TestUtils;
using Microsoft.AspNetCore.Identity;
using WynajemMaszyn.Domain.Entities;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WynajemMaszyn.Application.UnitTests.ExcavatorBuckets.Commands.CreateExcavatorBucket
{
    public class CreateExcavatorBucketCommandHandlerTests
    {
        private readonly CreateExcavatorBucketCommandHandler _handler;
        private readonly Mock<IExcavatorBucketRepository> _mockCreateExcavatorBucketCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<ICurrentUserService> _mockUserService;


        public CreateExcavatorBucketCommandHandlerTests()
        {
            _mockCreateExcavatorBucketCommandHandler = new Mock<IExcavatorBucketRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockUserService = new Mock<ICurrentUserService>();
            _handler = new CreateExcavatorBucketCommandHandler(_mockCreateExcavatorBucketCommandHandler.Object, _mockMachineryRepositoryHandler.Object, _mockUserService.Object);
        }


        [Fact]
        public async Task Handle_Should_ReturnErrorCreateExcavator_WhenIsNotValue()
        {
            //arange
            var createExcavatorBucketCommand = CreateExcavatorBucketCommandUtils.CreateExcavatorBucketCommand();


            //act
            var result = await _handler.Handle(createExcavatorBucketCommand, default);

            //Assert
            result.IsError.Should().BeTrue();

        }


        [Fact]
        public async Task Handle_Should_ReturnCreateExcavator_WhenIsValue()
        {
            //arange
            var createExcavatorBucketCommand = CreateExcavatorBucketCommandUtils.CreateExcavatorBucketCommand();



            //act
            var result = await _handler.Handle(createExcavatorBucketCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }
    }
}


     