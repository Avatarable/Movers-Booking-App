using Movars.Core.Models.DTOs;
using System.Net.Mail;

namespace Movars.Core.Services.Interfaces
{
    public interface IMailService
    {
        Task SendMailAsync(EmailMessage contact);
    }
}
