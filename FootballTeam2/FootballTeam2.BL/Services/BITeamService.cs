using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FootballTeam2.BL.Interfaces;
using FootballTeam2.DL.Interfaces;
using FootballTeam2.Models.DTO;
using FootballTeam2.Models.Responses;

namespace FootballTeam2.BL.Services
{
    internal class BlTeamService : IBlTeamService
    {
        private readonly ITeamService _teamService;
        private readonly IPlayerRepository _playerRepository;

        public BlTeamService(ITeamService teamService, IPlayerRepository playerRepository)
        {
            _teamService = teamService;
            _PlayerRepository = playerRepository;
        }

        public async Task<List<FullTeamDetails>> GetAllTeamDetails()
        {
            var result = new List<FullTeamDetails>();

            var teams = await _teamService.GetTeams();

            foreach (var team in teams)
            {
                var teamDetails = new FullTeamDetails();
                teamDetails.Title = team.Title;
                teamDetails.Year = team.Year;
                teamDetails.Id = team.Id;

                var players = await
                    _playerRepository.GetPlayers(team.Players);

                teamDetails.Players = players;
                result.Add(teamDetails);
            }
            return result;
        }
    }
}
