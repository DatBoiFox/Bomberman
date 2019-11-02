using Client.Resources.Prototype;

namespace Client.Models
{
    public class Bomb : IGameObject, IBombPrototype
    {
        public int id { get; set; }
        public int x { get;set; }
        public int y { get; set; }

        public Bomb(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Bomb Clone()
        {
            return new Bomb(x, y);
        }
    }
}
