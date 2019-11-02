using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Resources.Bridge
{
    class Blue : IColor
    {
        public Color GetColor()
        {
            return Color.Blue;
        }
    }
}
