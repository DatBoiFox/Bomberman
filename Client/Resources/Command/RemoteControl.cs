using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Resources.MementoPattern;

namespace Client.Resources.Command
{
    class RemoteControl
    {
        //private List<ICommand> commands = new List<ICommand>();
        private List<Memento> mementoes = new List<Memento>();

        public void undo()
        {
            if (mementoes.Count > 0)
            {
                mementoes.Last().restore();
                mementoes.RemoveAt(mementoes.Count - 1);
            }
        }
        public void MoveForward(Player player)
        {
            ICommand forward = new Forward(player);
            mementoes.Add(new Memento(player));
            forward.move();
            //commands.Add(forward);
        }
        public void MoveBackward(Player player)
        {
            ICommand backward = new Backward(player);
            mementoes.Add(new Memento(player));
            backward.move();
            //commands.Add(backward);
        }
        public void MoveLeft(Player player)
        {
            ICommand left = new Left(player);
            mementoes.Add(new Memento(player));
            left.move();
            //commands.Add(left);
        }
        public void MoveRight(Player player)
        {
            ICommand right = new Right(player);
            mementoes.Add(new Memento(player));
            right.move();
            //commands.Add(right);
        }
    }
}
