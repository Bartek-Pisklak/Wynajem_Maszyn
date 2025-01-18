using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Common.Errors;
using WynajemMaszyn.Application.Common.Interfaces.Authentication;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.Contracts.Authentication;

namespace WynajemMaszyn.Application.Authentication.Commands.Login;

public class LoginHandler : IRequestHandler<LoginCommand, ErrorOr<LoginResponse>>
{


    public LoginHandler()
    {
    }

    public async Task<ErrorOr<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {

        return new LoginResponse("Successfull!");
    }
}