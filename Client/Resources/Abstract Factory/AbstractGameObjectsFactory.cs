using Client.Resources.Abstract_Factory.Bomb_Factory;
using Client.Resources.Abstract_Factory.Player_Factory;
using Client.Resources.Strategy;
using System.Collections.Generic;

namespace Client.Resources.Abstract_Factory
{
    public abstract class AbstractGameObjectsFactory
    {
        public abstract IPlayerCreator CreatePlayer();
        public abstract IBombCreator CreateBomb(string strategy);
    }
}
