using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Resources.Command
{
    class Backward : ICommand
    {
        private Player player;

        public Backward(Player player)
        {
            this.player = player;
        }

        public void move()
        {
            player.y += 2;
        }

        public void undo()
        {
            //player.y -= 2;
        }
    }
}
