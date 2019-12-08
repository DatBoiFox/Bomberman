using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Resources.ChainOfResponsibility
{
    abstract class AbstractLogger
    {
        protected int type;
        protected AbstractLogger nextLogger;
        protected List<AbstractLogger> loggers;

        public abstract void setNextLogger();
        public abstract void logMessage(string logMessage);
    }
}
