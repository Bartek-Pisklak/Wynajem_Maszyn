using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Common.Errors;
using WynajemMaszyn.Application.Common.Interfaces.Authentication;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.Contracts.Authentication;

namespace WynajemMaszyn.Application.Authentication.Commands.Login;

public class LoginHandler : IRequestHandler<LoginCommand, ErrorOr<LoginResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUser(request.Email, request.Password);
        var permision = await _userRepository.GetUserPermission(user.PermissionId);

        //In the future we need to implement account verification confirmation here


        if (user is null) return Errors.User.BadData;

        return new LoginResponse("Successfull!");
    }
}