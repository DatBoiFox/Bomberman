using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Resources.Iterator;

namespace Client.Resources.Visitor
{
    public class GetCountIteratorVisitor : IteratorVisitor
    {
        public override int visitCount(MapItemIterator mapItemIterator)
        {
            MapItemRepository repository = mapItemIterator.GetMapItemRepository();
            return repository.Count;
        }
    }
}
