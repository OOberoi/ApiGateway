namespace Ocelot.Demo.Api2.Services
{
    /// <summary>
    /// An interface for Mail Service
    /// </summary>
    public interface IMailService
    {
        /// <summary>
        /// Siganature for Sending a subject body and message
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        void Send(string subject, string message);
    }
}