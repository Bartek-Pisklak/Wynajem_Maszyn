using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Security.Claims;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.EditExcavatorBuckets;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.ExcavatorBuckets.TestUtils;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.UnitTests.ExcavatorBuckets.Commands.EditExcavatorBucket
{
    public class EditExcavatorBucketCommandHandlerTests
    {
        private readonly EditExcavatorBucketCommandHandler _handler;
        private readonly Mock<IExcavatorBucketRepository> _mockEditExcavatorBucketCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<ICurrentUserService> _mockCurrentUserService;

        public EditExcavatorBucketCommandHandlerTests()
        {
            _mockEditExcavatorBucketCommandHandler = new Mock<IExcavatorBucketRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockCurrentUserService = new Mock<ICurrentUserService>();
            _handler = new EditExcavatorBucketCommandHandler(_mockEditExcavatorBucketCommandHandler.Object, _mockMachineryRepositoryHandler.Object, _mockCurrentUserService.Object);
        }


        [Fact]
        public async Task Handle_Should_ReturnErrorEditExcavator_WhenIsNotValue()
        {
            //arange
            var EditExcavatorBucketCommand = EditExcavatorBucketCommandUtils.EditExcavatorBucketCommand();

            _mockCurrentUserService.Setup(x => x.UserId)
            .Returns(value: null);
            //act
            var result = await _handler.Handle(EditExcavatorBucketCommand, default);

            //Assert
            result.IsError.Should().BeTrue();

        }


        [Fact]
        public async Task Handle_Should_ReturnEditExcavator_WhenIsValue()
        {
            //arange
            var EditExcavatorBucketCommand = EditExcavatorBucketCommandUtils.EditExcavatorBucketCommand();

            _mockCurrentUserService.Setup(x => x.UserId)
            .Returns("1");

            _mockCurrentUserService.Setup(x => x.Roles)
            .Returns(new List<string> { "Worker" });

            //act
            var result = await _handler.Handle(EditExcavatorBucketCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }
    }
}
