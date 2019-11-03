using Client.Models;
using Client.Resources.Decorator;
using System;
using Client.Resources.Adapter.Adapter_2;
using Client.Resources.Bridge;
using Client.Resources._Interfaces;

namespace Client.Resources.Models
{
    public class Crate : MapItemDecorator
    {
        public IPowerUp powerUp { get; set; }

        public Crate(IMapItems wrappee) : base(wrappee)
        {

        }

        public Crate(int x, int y, IColor color, IMap map, IMapItems wrappee) : base(wrappee)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            this.map = map;
        }

        public Crate(int x, int y, IColor color, IMap map, IMapItems wrappee, IPowerUp powerUp) : base(wrappee)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            this.map = map;
            this.powerUp = powerUp;
        }

        public override void AddMapItem()
        {
            wrappee.AddMapItem();
            map.AddItemToList(this);
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
