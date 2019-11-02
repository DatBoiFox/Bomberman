using Client.Models;
using System.Windows.Forms;

namespace Client.Resources.Abstract_Factory.Player_Factory
{
    public interface IPlayerCreator
    {
        PictureBox CreatePlayerModel(Player player);
    }
}
