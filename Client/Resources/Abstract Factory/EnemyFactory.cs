using Client.Resources.Abstract_Factory.Bomb_Factory;
using Client.Resources.Abstract_Factory.Player_Factory;
using Client.Resources.Strategy;

namespace Client.Resources.Abstract_Factory
{
    class EnemyFactory : AbstractGameObjectsFactory
    {
        public override IBombCreator CreateBomb(BombStrategy strategy)
        {
            return BombCreatorHandler.GetEnemyBombCreator(strategy);
        }

        public override IPlayerCreator CreatePlayer()
        {
            return PlayerCreatorHandler.GetEnemyCreator();
        }
    }
}
