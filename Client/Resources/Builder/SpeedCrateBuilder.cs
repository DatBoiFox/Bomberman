using Client.Resources.Models;

namespace Client.Resources.Builder
{
    class SpeedCrateBuilder : IPowerUpCrateBuilder
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
            crate.powerUp = "Speed";
        }

        public Crate GetCrate()
        {
            return crate;
        }
    }
}
