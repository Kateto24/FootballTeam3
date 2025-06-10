using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FootballTeam2.Models.DTO;

namespace FootballTeam2.DL.Interfaces
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetTeams();

        Task AddTeam(Team team);

        Task DeleteTeam(string id);

        Task<Team?> GetTeamsById(string id);
    }
}
