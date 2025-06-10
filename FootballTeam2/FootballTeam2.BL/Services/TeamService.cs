using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using FootballTeam2.BL.Interfaces;
using FootballTeam2.DL.Interfaces;
using FootballTeam2.Models.DTO;

namespace FootballTeam2.BL.Services
{
    internal class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IPlayerRepository _playerRepository;

        public TeamService(ITeamRepository teamRepository, IPlayerRepository playerRepository)
        {
            _teamRepository = teamRepository;
            _playerRepository = playerRepository;
        }

        public async Task<List<Team>> GetTeams()
        {
            return await _teamRepository.GetTeams();
        }

        public async Task AddTeam(Team team)
        {
            if (team == null || team.Players == null) return;

            foreach (var player in team.Players)
            {
                if (!Guid.TryParse(player, out _)) return;
            }

            await _teamRepository.AddTeam(team);
        }

        public async Task DeleteTeam(string id)
        {
            if (!string.IsNullOrEmpty(id)) return;

            await _teamRepository.DeleteTeam(id);
        }

        public async Task<Team?> GetTeamsById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var teamId))
            {
                return null;
            }

            return await _teamRepository.GetTeamsById(teamId.ToString());
        }

        public async Task AddPlayer(string teamId, Player player)
        {
            if (string.IsNullOrEmpty(teamId) || player == null) return;

            if (!Guid.TryParse(teamId, out _)) return;

            var team = await _teamRepository.GetTeamsById(teamId);

            if (team == null) return;

            if (team.Actors == null)
            {
                team.Actors = new List<string>();
            }

            if (player.Id == null || string.IsNullOrEmpty(player.Id) || Guid.TryParse(player.Id, out _) == false) return;

            var existingPlayer = await _playerRepository.GetById(player.Id);

            if (existingPlayer != null) return;

            team.Players.Add(player.Id);
        }
    }
}
