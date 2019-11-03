using Client.Resources._Interfaces;
using Client.Resources.Bridge;
using Client.Resources.Decorator;
using Client.Resources.Models;

namespace Client.Resources.Builder
{
    class PowerUpCrateBuildDirector
    {
        public void Construct(IPowerUpCrateBuilder builder, int x, int y, IMap map, IMapItems wrappee)
        {
            builder.CreateCrate();
            builder.SetPosition(x, y);
            builder.AddPowerUp();
            builder.SetColor();
            builder.SetMap(map);
            builder.SetWrappee(wrappee);
        }
    }
}
