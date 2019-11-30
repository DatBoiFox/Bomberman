using Client.Models;
using Client.Resources.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Resources.Proxy
{
    interface IConnectionHandler
    {
        bool ConnectionEstablished { get; }
        Task UpdatePlayer();
        Task UpdateBombs(Form form, Label lab);
        Task Update(Form form, Label lab);
        Player ClientPlayer { get; }
        PictureBox ClientPlayerBox { get; }
        List<Bomb> PlayerPlacedBombs { get; }
        Dictionary<int, PictureBox> PlayerPlacedBombModels { get; }
        Task PostBomb(Bomb b, string bombType);
        Task Connect(Form form);
        Task Disconnect(Form form);
        IConnectionState State { get; set; }
    }
}
