using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mapster;
using FootballTeam2.Models.DTO;
using FootballTeam2.Models.Requests;

namespace FootballTeam2.MapsterConfig
{
    public class MapsterConfiguration
    {
        public static void Configure()
        {
            TypeAdapterConfig<AddMovieRequest, Movie>  //Change Movie
                .NewConfig();
        }
    }
}
