using Client.Resources.Prototype;

namespace Client.Models
{
    public class Bomb : IGameObject, IBombPrototype
    {
        public int id { get; private set; }
        public int x { get; private set; }
        public int y { get; private set; }

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
