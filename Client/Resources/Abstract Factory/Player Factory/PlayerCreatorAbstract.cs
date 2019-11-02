using Client.Models;
using System.Drawing;
using System.Windows.Forms;

namespace Client.Resources.Abstract_Factory.Player_Factory
{
    public abstract class PlayerCreatorAbstract : IPlayerCreator
    {
        public PictureBox CreatePlayerModel(Player player)
        {
            PictureBox box = new PictureBox
            {
                Name = GetPictureName(),
                Size = GetPictureSize(),
                Location = GetLocation(player),
                BackColor = GetPictureColor()
            };
            return box;
        }

        protected abstract string GetPictureName();

        protected abstract Size GetPictureSize();

        protected abstract Point GetLocation(Player player);

        protected abstract Color GetPictureColor();

    }
}
