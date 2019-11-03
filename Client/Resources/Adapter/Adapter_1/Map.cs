using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.Resources.Decorator;

namespace Client.Resources.Adapter.Adapter_1
{
    public class Map
    {
        public List<IGameObject> mapItems { get; set; }

        public Map()
        {
            mapItems = new List<IGameObject>();
        }

        public void AddItemToList(IGameObject item)
        {
            mapItems.Add(item);
        }
    }
}
