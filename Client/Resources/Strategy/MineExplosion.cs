using System.Drawing;

namespace Client.Resources.Strategy
{
    class MineExplosion : BombStrategy
    {
        public override Color Explode()
        {
            return Color.Orange;
        }
    }
}
