using Microsoft.Extensions.DependencyInjection;
using FootballTeam2.DL.Interfaces;
using FootballTeam2.DL.Repositories;
using FootballTeam2.DL.Repositories.MongoRepositories;

namespace FootballTeam2.DL
{
    public static class DependencyInjection
    {
        public static IServiceCollection
            AddDataDependencies(
                this IServiceCollection services)
        {
            services.AddSingleton<ITeamRepository, TeamsRepository>();
            services.AddSingleton<IPlayerRepository, PlayerRepository>();

            return services;
        }
    }
}