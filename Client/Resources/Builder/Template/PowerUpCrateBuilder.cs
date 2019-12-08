using Client.Resources._Interfaces;
using Client.Resources.Adapter.Adapter_1;
using Client.Resources.Bridge;
using Client.Resources.Decorator;
using Client.Resources.Models;

namespace Client.Resources.Builder
{
    public abstract class PowerUpCrateBuilder
    {
        protected Crate crate;

        public void ConstructCrate(int x, int y, IMap map, IMapItems wrappee)
        {
            CreateCrate();
            SetPosition(x, y);
            AddPowerUp();
            SetColor();
            SetMap(map);
            SetWrappee(wrappee);
        }

        public virtual void CreateCrate()
        {
            crate = new Crate(new MapAdapter());
        }

        public virtual void SetPosition(int x, int y)
        {
            crate.x = x;
            crate.y = y;
        }

        public abstract void AddPowerUp();

        public abstract void SetColor();

        public virtual void SetMap(IMap map)
        {
            crate.map = map;
        }

        public virtual void SetWrappee(IMapItems item)
        {
            crate.wrappee = item;
        }

        public Crate GetCrate()
        {
            return crate;
        }
    }
}
