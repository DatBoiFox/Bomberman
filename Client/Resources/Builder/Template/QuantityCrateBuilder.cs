using Client.Resources._Interfaces;
using Client.Resources.Adapter.Adapter_1;
using Client.Resources.Adapter.Adapter_2;
using Client.Resources.Bridge;
using Client.Resources.Decorator;
using Client.Resources.Models;

namespace Client.Resources.Builder
{
    class QuantityCrateBuilder : PowerUpCrateBuilder
    {
        public override void AddPowerUp()
        {
            crate.powerUp = new PowerUpAdapter("Quantity");
        }

        public override void SetColor()
        {
            crate.color = new Brown();
        }

    }
}
