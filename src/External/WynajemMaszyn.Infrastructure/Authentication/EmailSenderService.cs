using WynajemMaszyn.Application.Persistance.Auth;

namespace WynajemMaszyn.Infrastructure.Authentication
{
    public class EmailSenderService : IEmailSenderService
    {
        public async Task SendConfirmationLinkAsync(string email, string confirmationLink)
        {
            var subject = "Potwierdzenie rejestracji";
            var body = $"Kliknij w poniższy link, aby potwierdzić swoje konto:\n\n<a href='{confirmationLink}'>{confirmationLink}</a>";

            // Implementacja wysyłania wiadomości e-mail
            await SendEmailAsync(email, subject, body);
        }

        private Task SendEmailAsync(string email, string subject, string body)
        {
            // Tu dodaj kod integracji z dostawcą e-mail (SMTP, SendGrid, itp.)
            return Task.CompletedTask;
        }


    }
}
