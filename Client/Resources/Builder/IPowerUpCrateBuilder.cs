using Client.Resources.Models;

namespace Client.Resources.Builder
{
    public interface IPowerUpCrateBuilder
    {
        void CreateCrate();

        void SetPosition(int x, int y);

        void AddPowerUp();

        Crate GetCrate();
    }
}
