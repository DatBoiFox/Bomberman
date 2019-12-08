using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Resources.ChainOfResponsibility
{
    class FileLogger : AbstractLogger
    {
        public FileLogger(int type)
        {
            this.type = type;
        }

        public override void setNextLogger()
        {
            Debug.Write("we are passing this shit unto the next logger");
            this.nextLogger = new InformationLogger(type);
        }

        public override void logMessage(string logMessage)
        {
            if (this.type == 3)
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
