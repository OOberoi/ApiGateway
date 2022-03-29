namespace Ocelot.Demo.Api2.Services
{
    public class MailService : IMailService
    {
        private string _mailTo = "obi@eOberoi.com";
        public string _mailFrom = "noreply@eOberoi.com";

        public MailService(IConfiguration configuration)
        {
            _mailTo = configuration["mailSettings:mailToAddress"];
            _mailFrom = configuration["mailSettings:MailFromAddress"];
        }

        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail from {_mailTo} to {_mailTo}, with {nameof(MailService)}.");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }

    }
}
