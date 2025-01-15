using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Contracts.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace WynajemMaszyn.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<RegisterResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMachineryRentalRepository _machineryRentalRepository;

    private readonly UserManager<User> UserManager;
    private readonly SignInManager<User> SignInManager;
    private readonly IUserStore<User> UserStore;
    private readonly IEmailSender<User> EmailSender;



    public RegisterCommandHandler(IUserRepository userRepository, 
        IMachineryRentalRepository machineryRentalRepository,
        UserManager<User> _UserManager,
        SignInManager<User> _SignInManager,
        IUserStore<User> _UserStore,
        IEmailSender<User> _EmailSender
        )
    {
        _userRepository = userRepository;
        _machineryRentalRepository = machineryRentalRepository;
        UserManager = _UserManager;
        SignInManager = _SignInManager;
        UserStore = _UserStore;
        EmailSender = _EmailSender;
    }

    public async Task<ErrorOr<RegisterResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var registerResponse = new RegisterResponse();


        var user = CreateUser();

        await UserStore.SetUserNameAsync(user, request.Email, CancellationToken.None);
        var emailStore = GetEmailStore();
        await emailStore.SetEmailAsync(user, request.Email, CancellationToken.None);
        user.FirstName  = request.FirstName;
        user.LastName = request.LastName;
        var result = await UserManager.CreateAsync(user, request.Password);




        if (!result.Succeeded)
        {
            registerResponse.Succeeded = false;
            registerResponse.identityErrors = result.Errors;
            return registerResponse;
        }
        registerResponse.Succeeded = true;

        var userId = await UserManager.GetUserIdAsync(user);
        var code = await UserManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

        registerResponse.userId = userId;
        registerResponse.code = code;
        registerResponse.RequireConfirmedAccount = UserManager.Options.SignIn.RequireConfirmedAccount;
        registerResponse.user = user;

        await SignInManager.SignInAsync(user, isPersistent: false);


        MachineryRental blank = new MachineryRental();
        blank.UserId = userId;

        await _machineryRentalRepository.CreateMachineryRental(blank);

        return registerResponse;
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

    private IUserEmailStore<User> GetEmailStore()
    {
        if (UserManager.SupportsUserEmail)
        {
            throw new NotSupportedException("The default UI requires a user store with email support.");
        }
        return (IUserEmailStore<User>)UserStore;
    }
}