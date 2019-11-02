using Client.Resources.Abstract_Factory.Bomb_Factory;
using Client.Resources.Abstract_Factory.Player_Factory;
using Client.Resources.Strategy;

namespace Client.Resources.Abstract_Factory
{
    public class PlayerFactory : AbstractGameObjectsFactory
    {
        public override IBombCreator CreateBomb(BombStrategy strategy)
        {
            return BombCreatorHandler.GetPlayerBombCreator(strategy);
        }

        public override IPlayerCreator CreatePlayer()
        {
            return PlayerCreatorHandler.GetPlayerCreator();
        }
    }
}
