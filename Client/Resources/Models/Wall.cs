using Client.Resources.Bridge;
using Client.Resources.Decorator;

namespace Client.Models
{
    public class Wall : MapItemDecorator
    {
        public Wall(int x, int y, IColor color, IMapItems wrappee) : base(wrappee)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }

        public override void AddMapItem()
        {
            wrappee.AddMapItem();
            // create wall in map;
        }
    }
}
