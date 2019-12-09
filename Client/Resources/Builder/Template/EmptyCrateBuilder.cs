using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Resources.Adapter.Adapter_2;

namespace Client.Resources.Builder.Template
{
    class EmptyCrateBuilder : PowerUpCrateBuilder
    {
        public override void AddPowerUp()
        {
            crate.powerUp = new NoPowerUpAdapter();
        }

        public override void SetColor()
        {
            crate.color = null;
        }
    }
}
