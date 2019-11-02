using Client.Models;
using System;
using Client.Resources.Adapter.Adapter_2;

namespace Client.Resources.Models
{
    public class Crate : IGameObject
    {
        public int id { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        //public string powerUp { get; set; }
        public IPowerUp powerUp { get; set; }

        public Crate()
        {
        }
        public Crate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Crate(int x, int y, IPowerUp powerUp)
        {
            this.x = x;
            this.y = y;
            this.powerUp = powerUp;
        }
        public void ShowCrate()
        {
            throw new Exception("Crate with : " + powerUp);
        }
    }
}
