using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Resources.State
{
    class DisconnectingState : IConnectionState
    {
        public string displayState()
        {
            return "Disconnecting";
        }
    }
}
