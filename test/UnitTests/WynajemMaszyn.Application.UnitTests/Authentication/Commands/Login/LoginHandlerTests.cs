using FluentAssertions;
using Moq;
using WynajemMaszyn.Application.Authentication.Commands.Login;
using WynajemMaszyn.Application.Common.Interfaces.Authentication;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.Authentication.Commands.TestUtils;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.UnitTests.Authentication.Commands.Login;

public class LoginHandlerTests
{
    private readonly LoginHandler _handler;
    private readonly Mock<IUserRepository> _mockIUserRepository;
    private readonly Mock<IJwtTokenGenerator> _mockIJwtTokenGenerator;

    public LoginHandlerTests()
    {
        _mockIUserRepository = new Mock<IUserRepository>();
        _mockIJwtTokenGenerator = new Mock<IJwtTokenGenerator>();
        _handler = new LoginHandler(_mockIUserRepository.Object, _mockIJwtTokenGenerator.Object);
    }

    [Fact]
    public async Task Handle_Should_ReturnErrorBadData_WhenLoginDataAreBad()
    {
        //Arrange
        var loginCommand = LoginCommandUtils.LoginCommand();

        _mockIUserRepository
            .Setup(x => x.GetUser(It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(value: null);
        //Act

        var result = await _handler.Handle(loginCommand, default);

        //Assert
        result.IsError.Should().BeTrue();
    }

    [Fact]
    public async Task Handle_Should_ReturnLoginResponse_WhenUserExist()
    {
        //Arrange
        var loginCommand = LoginCommandUtils.LoginCommand();
        
        _mockIUserRepository
            .Setup(x => x.GetUser(It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(new User());
        
        _mockIJwtTokenGenerator
            .Setup(x => 
                x.GenerateToken(It.IsAny<int>(),It.IsAny<string>(),It.IsAny<string>()))
            .Verifiable();

        //Act
        var result = await _handler.Handle(loginCommand, default);

        //Assert
        result.IsError.Should().BeFalse();
    }
}