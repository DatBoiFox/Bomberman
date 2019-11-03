using Client.Resources._Interfaces;
using Client.Resources.Bridge;
using Client.Resources.Decorator;
using Newtonsoft.Json;

namespace Client.Models
{
    public class Wall : MapItemDecorator
    {

        public Wall(IMapItems wrappee) : base(wrappee)
        {

        }

        public Wall(int x, int y, IColor color, IMap map, IMapItems wrappee) : base(wrappee)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            this.map = map;
        }

        [JsonConstructor]
        public Wall(int x, int y) : base(null)
        {
            this.x = x;
            this.y = y;
        }

        public override void AddMapItem()
        {
            wrappee.AddMapItem();
            map.AddItemToList(this);
            // create wall in map;
        }
    }
}
