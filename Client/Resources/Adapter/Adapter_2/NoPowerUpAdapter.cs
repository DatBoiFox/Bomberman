using Client.Resources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Resources.Adapter.Adapter_2
{
    class NoPowerUpAdapter : IPowerUp
    {
        public int id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public PictureBox model { get; set; }

        public PowerUp powerUp;

        public NoPowerUpAdapter()
        {
            this.powerUp = null;
        }

        public string getPowerUpType()
        {
            return "No Power Up";
        }
    }
}
