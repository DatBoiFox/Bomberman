using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.Resources.Command;

namespace Client.Resources.Interpreter
{
    abstract class AbstractExpression
    {
        protected string expression;
        protected Player player;
        protected RemoteControl remoteControl;

        public abstract void execute();
    }
}
