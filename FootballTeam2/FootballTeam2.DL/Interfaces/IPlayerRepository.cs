using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using FootballTeam2.Models.DTO;

namespace FootballTeam2.DL.Interfaces
{
    public interface IPlayerRepository
    {
        Task<Player?> GetById(string id);

        Task<List<Player>> GetPlayers(List<string> playerIds);
    }
}
