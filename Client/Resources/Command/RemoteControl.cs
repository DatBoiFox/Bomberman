using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Resources.Command
{
    class RemoteControl
    {
        private List<ICommand> commands = new List<ICommand>();

        public void undo()
        {
            if (commands.Count > 0)
            {
                commands.Last().undo();
                commands.RemoveAt(commands.Count - 1);
            }
        }
        public void MoveForward(Player player)
        {
            ICommand forward = new Forward(player);
            forward.move();
            commands.Add(forward);
        }
        public void MoveBackward(Player player)
        {
            ICommand backward = new Backward(player);
            backward.move();
            commands.Add(backward);
        }
        public void MoveLeft(Player player)
        {
            ICommand left = new Left(player);
            left.move();
            commands.Add(left);
        }
        public void MoveRight(Player player)
        {
            ICommand right = new Right(player);
            right.move();
            commands.Add(right);
        }
    }
}
