using Client.Models;
using Client.Resources.Strategy;
using System.Drawing;

namespace Client.Resources.Abstract_Factory.Bomb_Factory
{
    public class SimplePlayerBomb : BombCreatorAbstract
    {
        private Color bombColor;
        protected override Point GetLocation(Bomb bomb)
        {
            return new Point(bomb.x, bomb.y);
        }

        protected override Color GetPictureColor()
        {
            return bombColor;
        }

        protected override string GetPictureName()
        {
            return "ClientBomb";
        }

        protected override Size GetPictureSize()
        {
            return new Size(20, 20);
        }

        public SimplePlayerBomb(BombStrategy strategy)
        {
            bombColor = strategy.Explode();
        }

    }
}
