
using Client.Models;
using System.Drawing;
using System.Windows.Forms;

namespace Client.Resources.Abstract_Factory.Bomb_Factory
{
    public abstract class BombCreatorAbstract : IBombCreator
    {
        public PictureBox CreateBombModel(Bomb bomb)
        {
            PictureBox box = new PictureBox
            {
                Name = GetPictureName(),
                Size = GetPictureSize(),
                Location = GetLocation(bomb),
                BackColor = GetPictureColor()
            };
            return box;
        }

        protected abstract string GetPictureName();

        protected abstract Size GetPictureSize();

        protected abstract Point GetLocation(Bomb bomb);

        protected abstract Color GetPictureColor();

    }
}
