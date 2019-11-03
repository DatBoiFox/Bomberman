﻿using Client.Resources._Interfaces;
using Client.Resources.Adapter.Adapter_1;
using Client.Resources.Adapter.Adapter_2;
using Client.Resources.Bridge;
using Client.Resources.Decorator;
using Client.Resources.Models;

namespace Client.Resources.Builder
{
    class QuantityCrateBuilder : IPowerUpCrateBuilder
    {
        private Crate crate;

        public void CreateCrate()
        {
            crate = new Crate(new MapAdapter());
        }

        public void SetPosition(int x, int y)
        {
            crate.x = x;
            crate.y = y;
        }

        public void AddPowerUp()
        {
            crate.powerUp = new PowerUpAdapter("Quantity");
        }

        public void SetColor()
        {
            crate.color = new Blue();
        }

        public void SetMap(IMap map)
        {
            crate.map = map;
        }

        public void SetWrappee(IMapItems item)
        {
            crate.wrappee = item;
        }

        public Crate GetCrate()
        {
            return crate;
        }
    }
}
