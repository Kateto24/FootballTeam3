﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeam2.Models.Configurations
{
    public class MongoDbConfiguration
    {
        public string ConnectionString { get; set; } = string.Empty;

        public string DatabaseName { get; set; } = string.Empty;
    }
}
