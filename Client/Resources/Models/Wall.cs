namespace Client.Models
{
    class Wall : IGameObject
    {
        public int id { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public Wall(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
