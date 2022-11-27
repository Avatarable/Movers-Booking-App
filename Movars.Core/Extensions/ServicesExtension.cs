using Movars.Core.Services.Implementations;
using Movars.Core.Services.Interfaces;

namespace Movars.Core.Extensions
{
    public static class ServicesExtension
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IMailService, MailService>();
        }
    }
}
