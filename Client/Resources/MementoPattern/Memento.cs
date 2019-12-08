using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Resources.MementoPattern
{
    public class Memento
    { 
        private int playerX;
        private int playerY;
        private Player player;

        public Memento(Player player)
        {
            this.player = player;
            this.playerX = player.x;
            this.playerY = player.y;
        }

        public void restore()
        {
            player.x = playerX;
            player.y = playerY;
        }
    }
}
