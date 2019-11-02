using Client.Models;
using System;

namespace Client.Resources.Models
{
    public class Crate : IGameObject
    {
        public int id { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public string powerUp { get; set; }
        public Crate()
        {
        }
        public Crate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Crate(int x, int y, string powerUp)
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
