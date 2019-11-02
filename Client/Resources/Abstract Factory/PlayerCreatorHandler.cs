using Client.Resources.Abstract_Factory.Player_Factory;

namespace Client.Resources.Abstract_Factory
{
    public class PlayerCreatorHandler
    {
        public static IPlayerCreator GetPlayerCreator()
        {
            return new SimplePlayerCreator();
        }

        public static IPlayerCreator GetEnemyCreator()
        {
            return new SimpleEnemyCreator();
        }

    }
}
