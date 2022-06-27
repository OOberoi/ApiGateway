namespace Ocelot.Demo.Api2.Services
{
    /// <summary>
    /// MailService interface
    /// </summary>
    public class MailService : IMailService
    {
        
        private readonly string _mailTo = String.Empty;
        /// <summary>
        /// prinvate vars
        /// </summary>
        public readonly string _mailFrom = String.Empty;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
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
