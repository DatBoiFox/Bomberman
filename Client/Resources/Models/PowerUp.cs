using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Resources.Models
{
    public class PowerUp
    {
        public string type { get; set; }

        public PowerUp(string type)
        {
            this.type = type;
        }
    }
}
