using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Resources.ChainOfResponsibility
{
    class ErrorLogger :AbstractLogger
    {
        public ErrorLogger(int type)
        {
            this.type = type;
        }

        public override void setNextLogger()
        {
            this.nextLogger = new FileLogger(type);
        }

        public override void logMessage(string logMessage)
        {
            if (this.type == 2)
            {
                Debug.Write(logMessage);
            }
            else if (type > 3 || type < 0)
            {

            }
            else
            {
                setNextLogger();
            }
        }
    }
}
