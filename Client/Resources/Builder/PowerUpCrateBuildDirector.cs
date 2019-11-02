using Client.Resources.Models;

namespace Client.Resources.Builder
{
    class PowerUpCrateBuildDirector
    {
        public void Construct(IPowerUpCrateBuilder builder, int x, int y)
        {
            builder.CreateCrate();
            builder.SetPosition(x, y);
            builder.AddPowerUp();
        }
    }
}
