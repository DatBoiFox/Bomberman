using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.Resources.Decorator;
using Client.Resources.Iterator;

namespace Client.Resources.Adapter.Adapter_1
{
    public class Map
    {
        public MapItemRepository mapItems { get; private set; }

        public Map()
        {
            mapItems = new MapItemRepository();
        }

        public void AddItemToMap(IGameObject item)
        {
            mapItems.Add(item);
        }
    }
}
