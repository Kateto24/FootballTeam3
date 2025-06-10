using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FootballTeam2.BackgroundServices;
using FootballTeam2.Models.Configurations;

namespace FootballTeam2.ServiceExtensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddConfigurations(
            this IServiceCollection services, IConfiguration config)
        {
            services.Configure<MongoDbConfiguration>(config.GetSection(nameof(MongoDbConfiguration)));

            return services;
        }

        public static IServiceCollection AddBackgroundServices(
            this IServiceCollection services)
        {
            services.AddHostedService<TestBackgroundService>();
            //services.AddHostedService<TestHostedService>();

            return services;
        }
    }
}
