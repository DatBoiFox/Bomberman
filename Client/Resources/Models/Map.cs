using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.Resources._Interfaces;

namespace Client.Resources.Models
{
    class Map
    {

        private List<IGameObject> mapItems;

        public Map()
        {
            this.mapItems = new List<IGameObject>();
        }

    }
}
