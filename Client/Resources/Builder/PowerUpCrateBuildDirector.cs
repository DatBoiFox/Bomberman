using Client.Resources._Interfaces;
using Client.Resources.Bridge;
using Client.Resources.Decorator;
using Client.Resources.Models;

namespace Client.Resources.Builder
{
    class PowerUpCrateBuildDirector
    {
        public void Construct(PowerUpCrateBuilder builder, int x, int y, IMap map, IMapItems wrappee)
        {
            builder.ConstructCrate(x, y, map, wrappee);
        }
    }
}
