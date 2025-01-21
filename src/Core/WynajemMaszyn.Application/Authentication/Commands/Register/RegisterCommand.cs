using MediatR;
using ErrorOr;
using WynajemMaszyn.Application.Contracts.Authentication;

namespace WynajemMaszyn.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string ConfirmPassword,
    string ReturnUrl
    ) : IRequest<ErrorOr<RegisterResponse>>;