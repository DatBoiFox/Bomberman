using Client.Models;
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
        public int id { get; protected set; }
        public int x { get; protected set; }
        public int y { get; protected set; }
        public IColor color { get; protected set; }

        public IGameObject GetMapItems();
    }
}
