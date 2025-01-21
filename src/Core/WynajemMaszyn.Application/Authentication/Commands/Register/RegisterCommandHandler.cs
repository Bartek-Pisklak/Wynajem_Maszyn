using ErrorOr;
using MediatR;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Contracts.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using Microsoft.Extensions.Logging;
using WynajemMaszyn.Application.Common.Errors;
using Microsoft.AspNetCore.Identity.UI.Services;
using WynajemMaszyn.Application.Persistance.Auth;

namespace WynajemMaszyn.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<RegisterResponse>>
{

    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IUserStore<User> _userStore;
    private readonly IEmailSenderService _emailSender;
    private readonly ILogger<RegisterCommandHandler> _logger;


    public RegisterCommandHandler(
        UserManager<User> userManager,
        IUserStore<User> userStore,
        IEmailSenderService emailSender,
        ILogger<RegisterCommandHandler> logger,
        SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _userStore = userStore;
        _emailSender = emailSender;
        _logger = logger;
        _signInManager = signInManager;
    }

    public async Task<ErrorOr<RegisterResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        // Tworzenie użytkownika
        var user = CreateUser();

        await _userStore.SetUserNameAsync(user, request.Email, cancellationToken);
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;

        // Próba utworzenia użytkownika
        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            var errorDescriptions = result.Errors.Select(e => e.Description).ToList();
            return Error.Conflict("User.RegistrationFailed", string.Join("; ", errorDescriptions));
        }

        _logger.LogInformation("User created a new account with password.");

        // Wygenerowanie tokenu potwierdzenia e-mail
        var userId = await _userManager.GetUserIdAsync(user);
        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var encodedCode = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

        // Budowanie linku potwierdzającego
        var baseUrl = "https://your-app-domain.com"; // Zmień na domenę swojej aplikacji
        var callbackUrl = string.Concat(
            baseUrl, "/Account/ConfirmEmail?",
            $"userId={Uri.EscapeDataString(userId)}&code={Uri.EscapeDataString(encodedCode)}&returnUrl={Uri.EscapeDataString(request.ReturnUrl ?? string.Empty)}");

        await _emailSender.SendConfirmationLinkAsync(user.Email, encodedCode);

        // Jeśli wymagane jest potwierdzenie konta
        if (_userManager.Options.SignIn.RequireConfirmedAccount)
        {
            return Errors.User.RequireConfirmedAccount;
        }

        // Automatyczne zalogowanie użytkownika
        await _signInManager.SignInAsync(user, isPersistent: false);

        return new RegisterResponse
        {
            UserId = userId,
            Email = user.Email,
            RequiresConfirmation = _userManager.Options.SignIn.RequireConfirmedAccount
        };
    }


    private User CreateUser()
    {
        try
        {
            return Activator.CreateInstance<User>();
        }
        catch
        {
            throw new InvalidOperationException($"Can't create an instance of '{nameof(User)}'. " +
                $"Ensure that '{nameof(User)}' is not an abstract class and has a parameterless constructor.");
        }
    }
}