using Client.Models;
using Client.Resources.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Resources.Iterator
{
    public class MapItemRepository : Container
    {
        private List<IGameObject> mapItems = new List<IGameObject>();

        public Iterator GetIterator()
        {
            return new MapItemIterator(this);
        }

        public void Add(IGameObject mapItem)
        {
            mapItems.Add(mapItem);
        }

        public int Count
        {
            get { return mapItems.Count; }
        }

        // Indexer
        public object this[int index]
        {
            get { return mapItems[index]; }
            set { mapItems.Add((IGameObject)value); }
        }
    }
}
