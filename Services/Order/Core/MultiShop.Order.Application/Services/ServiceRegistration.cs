using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MultiShop.Order.Application.Services
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddMediatR(c=> c.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
        }
    }
}
