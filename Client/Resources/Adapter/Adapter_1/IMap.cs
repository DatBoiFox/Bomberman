using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.Resources.Adapter.Adapter_1;
using Client.Resources.Decorator;
using Client.Resources.Iterator;

namespace Client.Resources._Interfaces
{
    public interface IMap : IMapItems
    {
        void AddItemToMap(IGameObject item);
        MapItemRepository GetMap();
    }
}
