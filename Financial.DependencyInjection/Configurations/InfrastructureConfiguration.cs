using Financial.DependencyInjection.Options;
using MassTransit;
using Microsoft.Extensions.Configuration;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructureConfiguration(this IServiceCollection services, IConfiguration config)
        {
            var rabbitMqOption = config.GetSection("RabbitMQ").Get<RabbitMqOption>();

            services.AddMassTransit(options =>
            {
                options.AddDelayedMessageScheduler();

                options.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(new Uri(rabbitMqOption.Url), h =>
                    {
                        h.Username(rabbitMqOption.UserName);
                        h.Password(rabbitMqOption.Password);
                    });
                });

            });

            services.AddMassTransitHostedService();

            return services;
        }
    }
}