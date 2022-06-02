using Financial.Application.FinancialApp;
using Financial.Application.FinancialApp.Interfaces;
using Financial.Application.Shared;
using Financial.Application.Shared.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IBaseNotification, BaseNotification>();
            services.AddScoped<IFinancialService, FinancialService>();
            return services;
        }
    }
}
