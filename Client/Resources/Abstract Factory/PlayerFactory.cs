using Client.Resources.Abstract_Factory.Bomb_Factory;
using Client.Resources.Abstract_Factory.Player_Factory;
using Client.Resources.Strategy;

namespace Client.Resources.Abstract_Factory
{
    public class PlayerFactory : AbstractGameObjectsFactory
    {
        public override IBombCreator CreateBomb(string strategy)
        {
            return BombCreatorHandler.GetBombCreator(strategy, "player");
        }

        public override IPlayerCreator CreatePlayer()
        {
            return PlayerCreatorHandler.GetPlayerCreator();
        }
    }
}
