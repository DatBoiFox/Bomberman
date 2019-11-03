using Client.Resources._Interfaces;
using Client.Resources.Bridge;
using Client.Resources.Decorator;
using Client.Resources.Models;

namespace Client.Resources.Builder
{
    public interface IPowerUpCrateBuilder
    {
        void CreateCrate();

        void SetPosition(int x, int y);

        void AddPowerUp();

        void SetColor();

        void SetMap(IMap map);

        void SetWrappee(IMapItems item);

        Crate GetCrate();
    }
}
