using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeam2.Models.Requests
{
    public class AddTeamRequest
    {
        public string TeamName { get; set; }

        public int Year { get; set; }

        public List<string> PlayerIds { get; set; }
    }
}
