

namespace WynajemMaszyn.Application.Persistance.Auth
{
    public interface IEmailSenderService
    {
        Task SendConfirmationLinkAsync(string email, string confirmationLink);
    }
}
