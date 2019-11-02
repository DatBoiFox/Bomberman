using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Resources.Prototype
{
    interface IBombPrototype
    {
        Bomb Clone();
    }
}
