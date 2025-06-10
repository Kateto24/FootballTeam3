using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FootballTeam2.DL.DB;
using FootballTeam2.DL.Interfaces;
using FootballTeam2.Models.DTO;

namespace FootballTeam2.DL.Repositories
{
    //internal class TeamStaticRepository : ITeamRepository
    //{
    //    public List<Team> GetTeams()
    //    {
    //        return StaticData.Teams;
    //    }

    //    public void AddTeam(Team team)
    //    {
    //        StaticData.Teams.Add(team);
    //    }
    //    public void DeleteTeam(int id)
    //    {
    //        if (id <= 0) return;

    //        var team = GetTeamsById(id);

    //        if (team != null)
    //        {
    //            StaticData.Teams.Remove(team);
    //        }
    //    }
    //    public Team? GetTeamsById(int id)
    //    {
    //        if (id <= 0) return null;

    //        return StaticData.Teams
    //            .FirstOrDefault(x => x.Id == id);
    //    }
    //}
}
