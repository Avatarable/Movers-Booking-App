namespace Movars.Core.Services.Interfaces
{
    public interface INotificationService
    {
        Task SendEmailAsync(string fromAddress, string toAddress, string subject, string message);
    }
}
