using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Resources.Adapter.Adapter_2
{
    public interface IPowerUp : IGameObject
    {
        String getPowerUpType();
    }
}
