using System.Drawing;

namespace Client.Resources.Strategy
{
    class HorizontalExplosion : BombStrategy
    {
        public override Color Explode()
        {
            return Color.Teal;
        }
    }
}
