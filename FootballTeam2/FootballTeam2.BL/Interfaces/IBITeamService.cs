using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FootballTeam2.Models.Responses;

namespace FootballTeam2.BL.Interfaces
{
    public interface IBITeamService
    {
        Task<List<FullTeamDetails>> GetAllTeamDetails();
    }
}
