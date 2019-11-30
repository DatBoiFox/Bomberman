using Client.Resources.Abstract_Factory.Bomb_Factory;
using Client.Resources.Abstract_Factory.Player_Factory;
using Client.Resources.Strategy;

namespace Client.Resources.Abstract_Factory
{
    public class EnemyFactory : AbstractGameObjectsFactory
    {
        public override IBombCreator CreateBomb(string strategy)
        {
            return BombCreatorHandler.GetBombCreator(strategy, "enemy");
        }

        public override IPlayerCreator CreatePlayer()
        {
            return PlayerCreatorHandler.GetEnemyCreator();
        }
    }
}
