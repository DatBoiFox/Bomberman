using Client.Resources.Abstract_Factory.Bomb_Factory;
using Client.Resources.Strategy;
using System.Collections.Generic;

namespace Client.Resources.Abstract_Factory
{
    public class BombCreatorHandler
    {
        private static Dictionary<string, IBombCreator> bombDictionary = new Dictionary<string, IBombCreator>();

        public static IBombCreator GetBombCreator(string strategy, string type)
        {
            IBombCreator bombCreator = null;
            if (bombDictionary.ContainsKey(strategy + type))
                bombCreator = bombDictionary[strategy + type];
            else
            {
                BombStrategy bombStrategy = null;
                switch (strategy)
                {
                    case "double": bombStrategy = new DoubleExplosion(); break;
                    case "horizontal": bombStrategy = new HorizontalExplosion(); break;
                    case "mine": bombStrategy = new MineExplosion(); break;
                    case "vertical": bombStrategy = new VerticalExplosion(); break;
                }
                switch (type)
                {
                    case "player": bombCreator = new SimplePlayerBomb(bombStrategy); break;
                    case "enemy": bombCreator = new SimpleEnemyBomb(bombStrategy); break;               
                }
                bombDictionary.Add(strategy + type, bombCreator);
            }
            return bombCreator;
        }
    }
}
