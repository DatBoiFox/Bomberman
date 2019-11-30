using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Resources.Iterator
{
    public interface Container
    {
        Iterator GetIterator();
    }
}
