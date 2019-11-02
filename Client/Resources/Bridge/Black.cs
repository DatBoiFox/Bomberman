using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Resources.Bridge
{
    class Black : IColor
    {
        public Color GetColor()
        {
            return Color.Black;
        }
    }
}
