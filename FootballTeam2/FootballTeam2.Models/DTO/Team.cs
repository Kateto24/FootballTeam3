using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeam2.Models.DTO
{
    public class Team
    {
        public string Id { get; set; }

        public string TeamName { get; set; }

        public int Year { get; set; }

        public List<string> Players { get; set; }
    }
}
