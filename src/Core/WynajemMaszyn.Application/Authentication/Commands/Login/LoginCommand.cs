using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.Authentication;

namespace WynajemMaszyn.Application.Authentication.Commands.Login;

public record LoginCommand(
    string Email,
    string Password
    ) : IRequest<ErrorOr<LoginResponse>>;