using Client.Models;
using Client.Resources.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Resources.Visitor;

namespace Client.Resources.Iterator
{
    public class MapItemRepository : Container
    {
        private List<IGameObject> mapItems = new List<IGameObject>();

        private IteratorVisitor iteratorVisitor;
        private MapItemIterator mapItemIterator;

        public Iterator GetIterator()
        {
            mapItemIterator = new MapItemIterator(this);

            return mapItemIterator;
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

        public bool acceptContains(ContainsIteratorVisitor visitor, IGameObject gameObject)
        {
            return visitor.visitContains(mapItemIterator, gameObject);
        }

        public IGameObject acceptLast(ContainsIteratorVisitor visitor)
        {
            return visitor.visitLast(mapItemIterator);
        }

        public int acceptCount(ContainsIteratorVisitor visitor)
        {
            return visitor.visitCount(mapItemIterator);
        }
    }
}
