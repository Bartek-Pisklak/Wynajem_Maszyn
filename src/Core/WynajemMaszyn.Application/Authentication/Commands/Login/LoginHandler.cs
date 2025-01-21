using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.Authentication;
using WynajemMaszyn.Application.Common.Errors;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Authentication.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, ErrorOr<LoginResponse>>
{
    private readonly SignInManager<User> _signInManager;
    private readonly ILogger<LoginCommandHandler> _logger;

    public LoginCommandHandler(
        SignInManager<User> signInManager,
        ILogger<LoginCommandHandler> logger)
    {
        _signInManager = signInManager;
        _logger = logger;
    }

    public async Task<ErrorOr<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var result = await _signInManager.PasswordSignInAsync(
            request.Email,
            request.Password,
            isPersistent: request.RememberMe,
            lockoutOnFailure: true);

        if (result.Succeeded)
        {
            _logger.LogInformation("User logged in.");
            return new LoginResponse
            {
                RedirectUrl = request.ReturnUrl ?? "/"
            };
        }

        if (result.RequiresTwoFactor)
        {
            return new LoginResponse
            {
                RequiresTwoFactor = true,
                RedirectUrl = $"/Account/LoginWith2fa?returnUrl={Uri.EscapeDataString(request.ReturnUrl ?? "/")}&rememberMe={request.RememberMe}"
            };
        }

        if (result.IsLockedOut)
        {
            _logger.LogWarning("User account locked out.");
            return new LoginResponse
            {
                IsLockedOut = true,
                RedirectUrl = "/Account/Lockout"
            };
        }

        return Errors.User.BadLoginData;
    }
}