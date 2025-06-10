using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using FootballTeam2.DL.Interfaces;
using FootballTeam2.Models.Configurations;
using FootballTeam2.Models.DTO;

namespace FootballTeam2.DL.Repositories.MongoRepositories
{
    internal class PlayerRepository : IPlayerRepository
    {
        private readonly IMongoCollection<Player> _playerCollection;
        private readonly ILogger<PlayerRepository> _logger;

        public PlayerRepository(ILogger<PlayerRepository> logger, IOptionsMonitor<MongoDbConfiguration> mongoConfig)
        {
            _logger = logger;

            if (string.IsNullOrEmpty(mongoConfig?.CurrentValue?.ConnectionString) || string.IsNullOrEmpty(mongoConfig?.CurrentValue?.DatabaseName))
            {
                _logger.LogError("MongoDb configuration is missing");

                throw new ArgumentNullException("MongoDb configuration is missing");
            }

            var client = new MongoClient(mongoConfig.CurrentValue.ConnectionString);
            var database = client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);
            _playerCollection = database.GetCollection<Player>($"{nameof(Player)}s");
        }

        public async Task AddPlayer(Player team)
        {
            try
            {
                team.Id = Guid.NewGuid().ToString();

                await _playerCollection.InsertOneAsync(team);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async Task DeletePlayer(string id)
        {
            await _playerCollection.DeleteOneAsync(m => m.Id == id);
        }

        public async Task<List<Player>> GetActors()
        {
            var result = await _playerCollection.FindAsync(m => true);

            return result.ToList();
        }

        public async Task<Player?> GetById(string id)
        {
            var result = await _playerCollection.FindAsync(m => m.Id == id);

            return result.FirstOrDefault();
        }

        public async Task<List<Player>> GetPlayers(List<string> playerIds)
        {
            var result = await
                _playerCollection.FindAsync(m => playerIds.Contains(m.Id.ToString()));

            return await result.ToListAsync();
        }
    }
}
