using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.Resources.Iterator;

namespace Client.Resources.Visitor
{
    public class IteratorVisitor
    {
        public virtual int visitCount(MapItemIterator mapItemIterator)
        {
            throw new NotImplementedException();
        }
        public virtual IGameObject visitLast(MapItemIterator mapItemIterator)
        {
            throw new NotImplementedException();
        }
        public virtual bool visitContains(MapItemIterator mapItemIterator, IGameObject gameObject)
        {
            throw new NotImplementedException();
        }
    }
}
