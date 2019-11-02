using System.Drawing;

namespace Client.Resources.Strategy
{
    class VerticalExplosion : BombStrategy
    {
        public override Color Explode()
        {
            return Color.Black;
        }
    }
}
