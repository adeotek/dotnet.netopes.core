using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace Netopes.Core.Helpers.Email
{
    public class EmailSender
    {
        private readonly EmailSettings _emailSettings;
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(EmailSettings emailSettings, ILogger<EmailSender> logger)
        {
            _emailSettings = emailSettings ?? throw new ArgumentNullException(nameof(emailSettings));
            _logger = logger;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                await Task.Run(() => SendEmail(email, subject, message));
            }
            catch (Exception e)
            {
                _logger?.LogError(e, "SendEmail exception");
                throw new InvalidOperationException(e.Message);
            }
        }

        private void SendEmail(string email, string subject, string message)
        {
            var bodyBuilder = new BodyBuilder { HtmlBody = message };
            var mailMessage = new MimeMessage { Subject = subject, Body = bodyBuilder.ToMessageBody() };
            mailMessage.From.Add(new MailboxAddress(_emailSettings.Label, _emailSettings.Email));
            mailMessage.To.Add(MailboxAddress.Parse(email));

            using var client = new SmtpClient();
            client.Connect(_emailSettings.Server, _emailSettings.Port, _emailSettings.Ssl);
            client.Authenticate(_emailSettings.Email, _emailSettings.Password);
            client.Send(mailMessage);
            client.Disconnect(true);
        }
    }
}
