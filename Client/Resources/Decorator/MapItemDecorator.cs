using Client.Models;
using Client.Resources._Interfaces;
using Client.Resources.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Resources.Decorator
{
    public abstract class MapItemDecorator : IMapItems, IGameObject
    {
        public int id { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public IColor color { get; set; }
        public IMap map { get; set; }

        public IMapItems wrappee { get; set; }

        public MapItemDecorator(IMapItems wrappee)
        {
            this.wrappee = wrappee;
        }

        public virtual void AddMapItem()
        {
            wrappee.AddMapItem();
        }
    }
}
