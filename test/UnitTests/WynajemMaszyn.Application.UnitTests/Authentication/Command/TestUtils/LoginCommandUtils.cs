using WynajemMaszyn.Application.Authentication.Commands.Login;
using WynajemMaszyn.Application.UnitTests.TestUtils.Constants;

namespace WynajemMaszyn.Application.UnitTests.Authentication.Commands.TestUtils;

public static class LoginCommandUtils
{
    public static LoginCommand LoginCommand() =>
        new LoginCommand(
            Constants.Login.Email,
            Constants.Login.Password,
            Constants.Login.RemenberMe,
            Constants.Login.ReturnUrl
            );
}