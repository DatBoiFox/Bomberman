using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.Resources._Interfaces;
using Client.Resources.Decorator;
using Client.Resources.Iterator;

namespace Client.Resources.Adapter.Adapter_1
{
    class MapAdapter : IMap
    {
        public Map map { get; set; }

        public MapAdapter()
        {
            map = new Map();
        }

        public void AddMapItem()
        {
            //map.mapItems.Add();
        }

        public void AddItemToMap(IGameObject item)
        {
            map.AddItemToMap(item);
        }

        public MapItemRepository GetMap()
        {
            return map.mapItems;
        }
    }
}
