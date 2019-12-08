using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.Resources.Adapter.Adapter_1;
using Client.Resources.Iterator;

namespace Client.Resources.Visitor
{
    public class GetLastIteratorVisitor : IteratorVisitor
    {
        public override IGameObject visitLast(MapItemIterator mapItemIterator)
        {
            if(mapItemIterator == null) { }
            MapItemRepository repository = mapItemIterator.GetMapItemRepository();
            IGameObject lastItem = null;
            while (!mapItemIterator.IsDone())
            {
                lastItem = (IGameObject)mapItemIterator.CurrentItem();
                mapItemIterator.Next();
            }

            return lastItem;
        }
    }
}
