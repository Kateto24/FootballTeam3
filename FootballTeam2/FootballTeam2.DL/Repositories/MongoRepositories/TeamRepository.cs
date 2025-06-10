using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MovieStoreB.DL.Interfaces;
using MovieStoreB.Models.Configurations;
using MovieStoreB.Models.DTO;

namespace FootballTeam2.DL.Repositories.MongoRepositories
{
    internal class TeamsRepository : ITeamRepository
    {
        private readonly IMongoCollection<Movie> _teamsCollection;
        private readonly ILogger<TeamsRepository> _logger;

        public TeamsRepository(ILogger<TeamsRepository> logger, IOptionsMonitor<MongoDbConfiguration> mongoConfig)
        {
            _logger = logger;

            if (string.IsNullOrEmpty(mongoConfig?.CurrentValue?.ConnectionString) || string.IsNullOrEmpty(mongoConfig?.CurrentValue?.DatabaseName))
            {
                _logger.LogError("MongoDb configuration is missing");

                throw new ArgumentNullException("MongoDb configuration is missing");
            }

            var client = new MongoClient(mongoConfig.CurrentValue.ConnectionString);
            var database = client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);

            _teamsCollection = database.GetCollection<Team>($"{nameof(Team)}s");
        }

        public async Task AddTeam(Team team)
        {
            try
            {
                team.Id = Guid.NewGuid().ToString();

                await _teamsCollection.InsertOneAsync(team);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async Task DeleteTeam(string id)
        {
            await _teamsCollection.DeleteOneAsync(m => m.Id == id);
        }

        public async Task<List<Team>> GetTeams()
        {
            var result = await _teamsCollection.FindAsync(m => true);

            return result.ToList();
        }

        public async Task<Team?> GetTeamsById(string id)
        {
            var result = await _teamsCollection.FindAsync(m => m.Id == id);

            return result.FirstOrDefault();
        }
    }
}
