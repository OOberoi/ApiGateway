namespace Ocelot.Demo.Api2.Services
{
    public class CloudMailService : IMailService
    {
        private string _mailTo = "obi@eOberoi.com";
        public string _mailFrom = "noreply@eOberoi.com";

        public CloudMailService()
        {

        }

        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail from {_mailTo} to {_mailTo}, with {nameof(CloudMailService)}.");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }

    }
}
