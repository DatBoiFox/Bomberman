using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.Resources.Iterator;

namespace Client.Resources.Visitor
{
    public class ContainsIteratorVisitor : IteratorVisitor
    {
        public override bool visitContains(MapItemIterator mapItemIterator, IGameObject gameObject)
        {
            MapItemRepository repository = mapItemIterator.GetMapItemRepository();
            bool contains = false;
            while (!mapItemIterator.IsDone())
            {
                if (gameObject == (IGameObject) mapItemIterator.CurrentItem())
                {
                    contains = true;
                }
                mapItemIterator.Next();
            }
            return contains;
        }
    }
}
