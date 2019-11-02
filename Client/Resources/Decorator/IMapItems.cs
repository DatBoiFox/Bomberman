﻿using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Resources.Decorator
{
    public interface IMapItems
    {
        void AddMapItem(IGameObject mapItem);
    }
}
