using Client.Models;
using Client.Resources.Decorator;
using System;
using Client.Resources.Adapter.Adapter_2;
using Client.Resources.Bridge;

namespace Client.Resources.Models
{
    public class Crate : MapItemDecorator
    {
        public IPowerUp powerUp { get; private set; }

        public Crate(int x, int y, IColor color, IMapItems wrappee) : base(wrappee)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }

        public Crate(int x, int y, IColor color, IMapItems wrappee, IPowerUp powerUp) : base(wrappee)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            this.powerUp = powerUp;
        }

        public override void AddMapItem()
        {
            wrappee.AddMapItem();
            // create crate in map;
        }

        public void ShowCrate()
        {
            throw new Exception("Crate with : " + powerUp);
        }

        public void Destroy()
        {

        }
    }
}
