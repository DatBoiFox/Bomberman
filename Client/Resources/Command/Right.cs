using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Resources.Command
{
    class Right : ICommand
    {

        private Player player;

        public Right (Player player)
        {
            this.player = player;
        }

        public void move()
        {
            player.x += 6;
        }

        public void undo()
        {
            player.x -= 6;
        }
    }
}
