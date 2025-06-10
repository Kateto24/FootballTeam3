using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using FootballTeam2.Models.DTO;

namespace FootballTeam2.BL.Interfaces
{
    public interface ITeamService
    {
        Task<List<Team>> GetTeams();

        Task AddTeam(Team team);

        Task DeleteTeam(string id);

        Task<Team?> GetTeamById(string id);

        Task AddPlayer(string teamId, Player player);
    }
}
