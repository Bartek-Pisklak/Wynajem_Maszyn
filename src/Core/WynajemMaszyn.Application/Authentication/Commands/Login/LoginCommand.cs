using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.Authentication;

namespace WynajemMaszyn.Application.Authentication.Commands.Login;

public record LoginCommand(
    string Email,
    string Password,
    bool RememberMe,
    string? ReturnUrl
    ) : IRequest<ErrorOr<LoginResponse>>;