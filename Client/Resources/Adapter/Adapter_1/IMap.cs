using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.Resources.Decorator;

namespace Client.Resources._Interfaces
{
    public interface IMap : IMapItems
    {
        void AddItemToList(IGameObject item);
    }
}
