using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Common.Errors;
using WynajemMaszyn.Application.Common.Interfaces.Authentication;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.Contracts.Authentication;
using System.Security.Claims;
using WynajemMaszyn.Application.Features.Excavators.Queries.DTOs;
using System.Net.Http;

namespace WynajemMaszyn.Application.Authentication.Commands.Login;

public class LoginHandler : IRequestHandler<LoginCommand, ErrorOr<LoginResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenGenerator TokenGenerator;

    public LoginHandler(IUserRepository userRepository, ITokenGenerator tokenGenerator)
    {
        _userRepository = userRepository;
        TokenGenerator = tokenGenerator;
    }

    public async Task<ErrorOr<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUser(request.Email, request.Password);

        if (user is null) return Errors.User.BadData;
        var permision = await _userRepository.GetUserPermission(user.PermissionId);

        string claimForToken = TokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName, permision);


        LoginResponse claimToken = new LoginResponse
        {
            Id= user.Id,
            claimForToken = claimForToken
        };
        return claimToken;
    }
}