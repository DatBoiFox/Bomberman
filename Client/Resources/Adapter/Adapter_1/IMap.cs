﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Resources.Decorator;

namespace Client.Resources._Interfaces
{
    interface IMap : IMapItems
    {
        void createMap();
    }
}
