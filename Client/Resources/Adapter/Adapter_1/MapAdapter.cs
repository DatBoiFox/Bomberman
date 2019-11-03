using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.Resources._Interfaces;
using Client.Resources.Decorator;

namespace Client.Resources.Adapter.Adapter_1
{
    class MapAdapter : IMap
    {
        public Map map { get; set; }

        public void AddMapItem()
        {
            //map.mapItems.Add();
        }

        public void AddItemToList(IGameObject item)
        {
            map.AddItemToList(item);
        }
    }
}
