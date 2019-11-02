using Client.Models;
using Client.Resources.Strategy;
using System.Drawing;

namespace Client.Resources.Abstract_Factory.Bomb_Factory
{
    class SimpleEnemyBomb : BombCreatorAbstract
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
            return "EnemyBomb";
        }

        protected override Size GetPictureSize()
        {
            return new Size(20, 20);
        }

        public SimpleEnemyBomb(BombStrategy strategy)
        {
            bombColor = strategy.Explode();
        }

    }
}
