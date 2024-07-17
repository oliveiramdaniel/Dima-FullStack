using Microsoft.AspNetCore.Identity.UI.Services;

namespace Api.Handlers
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Não faz nada
            return Task.CompletedTask;
        }
    }
}
