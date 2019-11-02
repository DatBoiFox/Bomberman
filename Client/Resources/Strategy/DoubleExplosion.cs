using System.Drawing;

namespace Client.Resources.Strategy
{
    class DoubleExplosion : BombStrategy
    {
        public override Color Explode()
        {
            return Color.White;
        }
    }
}
