using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using MailKit.Net.Smtp;
using MimeKit;
using lesson5_EmailSender.Models;

namespace lesson5_EmailSender.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailService> _logger;
        private readonly SmtpConfigModel _serverOptions;
        public EmailService(IConfiguration configuration, IOptions<SmtpConfigModel> options, ILogger<EmailService> logger)
        {
            _configuration = configuration;

            _serverOptions = options.Value;

            _logger = logger;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var EmailMessage = new MimeMessage();

            (string login, string password) account = (
                _configuration.GetValue<string>("login", ""), 
                _configuration.GetValue<string>("password", "")
                );

            if (string.IsNullOrWhiteSpace(account.login) || string.IsNullOrWhiteSpace(account.password))
            {
                _logger.LogError("Пустые логин и пароль");

                throw new InvalidOperationException("login or password is empty");
            }

            EmailMessage.From.Add(new MailboxAddress("service", account.login));
            EmailMessage.To.Add(new MailboxAddress(email));
            EmailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) {Text = message };
            EmailMessage.Subject = subject;

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_serverOptions.Server, _serverOptions.Port, _serverOptions.UseSecureConnection);
                await client.AuthenticateAsync(account.login, account.password);
                await client.SendAsync(EmailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
