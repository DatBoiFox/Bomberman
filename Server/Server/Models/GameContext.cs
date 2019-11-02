using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }

        //public DbSet<GameServer.Models.Player> Player { get; set; }

        //public DbSet<GameServer.Models.Bomb> Bomb { get; set; }

        //public DbSet<GameServer.Models.Coordinates> Coordinates { get; set; }
    }
}
