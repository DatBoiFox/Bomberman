using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Resources.State
{
    class RoomFullState : IConnectionState
    {
        public String displayState()
        {
            return "Room Full";
        }
    }
}
