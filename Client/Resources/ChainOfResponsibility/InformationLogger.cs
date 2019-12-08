using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Resources.ChainOfResponsibility
{
    class InformationLogger : AbstractLogger
    {
        public InformationLogger(int type)
        {
            this.type = type;
        }

        public override void setNextLogger()
        {
            this.nextLogger = new ExceptionLogger(type);
        }

        public override void logMessage(string logMessage)
        {
            if (this.type == 0)
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
