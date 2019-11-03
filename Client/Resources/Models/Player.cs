using System;

namespace Client.Models
{
    public class Player : IGameObject
    {
        public int id { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public Player()
        {
            x = 150;//new Random().Next(200);
            y = 150; //new Random().Next(200);
        }
    }
}
