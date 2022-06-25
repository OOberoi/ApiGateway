namespace Ocelot.Demo.Api2.Services
{
    /// <summary>
    /// An interface for Mail Service
    /// </summary>
    public interface IMailService
    {
        void Send(string subject, string message);
    }
}