using Movars.Core.Data.Repositories.Implementations;
using Movars.Core.Data.Repositories.Interfaces;
using Movars.Core.Services.Implementations;
using Movars.Core.Services.Interfaces;

namespace Movars.Core.Extensions
{
    public static class ServicesExtension
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            //register services

            services.AddScoped<IMailService, MailService>();

            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IBidRepository, BidRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IBidService, BidService>();
        }
    }
}
