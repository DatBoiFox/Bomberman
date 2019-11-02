using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Resources.Command
{
    class Left : ICommand
    {
        private Player player;

        public Left(Player player)
        {
            this.player = player;
        }

        public void move()
        {
            player.x -= 2;
        }

        public void undo()
        {
            player.x += 2;
        }
    }
}
