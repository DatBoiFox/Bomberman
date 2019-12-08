using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Resources.Mediator
{
    interface IMediator
    {
        void notify(int type, string logMessage);
    }
}
