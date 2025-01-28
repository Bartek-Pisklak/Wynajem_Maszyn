using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Moq;
using WynajemMaszyn.Application.Authentication.Commands.Login;
using WynajemMaszyn.Application.UnitTests.Authentication.Commands.TestUtils;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.UnitTests.Authentication.Commands.Login;

public class LoginHandlerTests
{
    private readonly LoginCommandHandler _handler;
    private readonly Mock<SignInManager<User>> _mockSignInManager;
    private readonly Mock<ILogger<LoginCommandHandler>> _mockLogger;


    public LoginHandlerTests()
    {
        _mockSignInManager = new Mock<SignInManager<User>>();
        _mockLogger = new Mock<ILogger<LoginCommandHandler>>();
        _handler = new LoginCommandHandler(_mockSignInManager.Object, _mockLogger.Object);
    }

    [Fact]
    public async Task Handle_Should_ReturnErrorBadData_WhenLoginDataAreBad()
    {
        //Arrange
        var loginCommand = LoginCommandUtils.LoginCommand();

        _mockSignInManager.Setup(x => x.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
            .ReturnsAsync(SignInResult.Success);
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

        _mockSignInManager
            .Setup(x => x.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
            .ReturnsAsync(SignInResult.Success);


        //Act
        var result = await _handler.Handle(loginCommand, default);

        //Assert
        result.IsError.Should().BeFalse();
    }
}