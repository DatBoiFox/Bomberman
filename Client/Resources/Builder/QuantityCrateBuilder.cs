using Client.Resources.Models;

namespace Client.Resources.Builder
{
    class QuantityCrateBuilder : IPowerUpCrateBuilder
    {
        private Crate crate;

        public void CreateCrate()
        {
            crate = new Crate();
        }

        public void SetPosition(int x, int y)
        {
            crate.x = x;
            crate.y = y;
        }

        public void AddPowerUp()
        {
            crate.powerUp = "Quantity";
        }

        public Crate GetCrate()
        {
            return crate;
        }
    }
}
