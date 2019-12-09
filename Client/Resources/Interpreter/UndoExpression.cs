using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.Resources.Command;

namespace Client.Resources.Interpreter
{
    class UndoExpression : AbstractExpression
    {
        public UndoExpression(RemoteControl remoteControl, Player player, string expression)
        {
            this.remoteControl = remoteControl;
            this.player = player;
            this.expression = expression;
        }

        public override void execute()
        {
            if (expression.Contains("undo"))
            {
                remoteControl.undo();
            }
        }
    }
}
