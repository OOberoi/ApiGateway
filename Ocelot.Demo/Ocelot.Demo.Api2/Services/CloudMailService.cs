﻿namespace Ocelot.Demo.Api2.Services
{
    /// <summary>
    /// Cloud Mail Service object
    /// </summary>
    public class CloudMailService : IMailService
    {
        private readonly string _mailTo = String.Empty;
        public readonly string _mailFrom = String.Empty;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public CloudMailService(IConfiguration configuration)
        {
            _mailTo = configuration["mailSettings:mailToAddress"];
            _mailFrom = configuration["mailSettings:MailFromAddress"];
        }

        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail from {_mailTo} to {_mailTo}, with {nameof(CloudMailService)}.");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }

    }
}
