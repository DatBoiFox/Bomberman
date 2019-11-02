using Client.Models;
using System.Windows.Forms;

namespace Client.Resources.Abstract_Factory.Bomb_Factory
{
    public interface IBombCreator
    {
        PictureBox CreateBombModel(Bomb bomb);
    }
}
