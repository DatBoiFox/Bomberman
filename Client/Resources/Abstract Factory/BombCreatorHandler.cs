using Client.Resources.Abstract_Factory.Bomb_Factory;
using Client.Resources.Strategy;

namespace Client.Resources.Abstract_Factory
{
    class BombCreatorHandler
    {
        public static IBombCreator GetPlayerBombCreator(BombStrategy strategy)
        {
            return new SimplePlayerBomb(strategy);
        }

        public static IBombCreator GetEnemyBombCreator(BombStrategy strategy)
        {
            return new SimpleEnemyBomb(strategy);
        }
    }
}
