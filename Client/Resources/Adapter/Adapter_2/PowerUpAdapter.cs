using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Resources.Models;

namespace Client.Resources.Adapter.Adapter_2
{
    class PowerUpAdapter : IPowerUp
    {

        public int id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public PictureBox model { get; set; }

        public PowerUp powerUp;

        public PowerUpAdapter(string type)
        {
            this.powerUp = new PowerUp(type);
        }

        public string getPowerUpType()
        {
            return powerUp.type;
        }

        
    }
}
