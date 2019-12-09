using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.Resources.Command;

namespace Client.Resources.Interpreter
{
    class MoveExpression : AbstractExpression
    {
        public MoveExpression(RemoteControl remoteControl, Player player, string expression)
        {
            this.remoteControl = remoteControl;
            this.player = player;
            this.expression = expression;
        }

        public override void execute()
        {
            if (expression.Contains("up"))
            {
                remoteControl.MoveForward(player);
            }
            else if(expression.Contains("down"))
            {
                remoteControl.MoveBackward(player);
            }
            else if(expression.Contains("left"))
            {
                remoteControl.MoveLeft(player);
            }
            else if (expression.Contains("right"))
            {
                remoteControl.MoveRight(player);
            }
        }
    }
}
