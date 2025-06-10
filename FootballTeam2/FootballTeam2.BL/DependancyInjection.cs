using Microsoft.Extensions.DependencyInjection;
using FootballTeam2.BL.Interfaces;
using FootballTeam2.BL.Services;

namespace FootballTeam2.BL
{
    public static class DependencyInjection
    {
        public static IServiceCollection
            AddBusinessDependencies(this IServiceCollection services)
        {
            services.AddSingleton<ITeamService, TeamService>();
            services.AddSingleton<IBlTeamService, BlTeamService>();
            return services;
        }
    }
}