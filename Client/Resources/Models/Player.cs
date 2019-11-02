using System;

namespace Client.Models
{
    public class Player : IGameObject
    {
        public int id { get; private set; }
        public int x { get; private set; }
        public int y { get; private set; }

        public Player()
        {
            x = new Random().Next(200);
            y = new Random().Next(200);
        }
    }
}
