using FootballTeam2.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using FootballTeam2.Models.DTO

namespace FootballTeam2.Models.Responses
{
    public class FullTeamDetails
    {
        public string Id { get; set; }

        public string TeamName { get; set; }

        public int Year { get; set; }

        public List<Player> Players { get; set; }
    }
}
