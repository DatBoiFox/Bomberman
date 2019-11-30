using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Resources.Iterator
{
    public interface Iterator
    {
        object First();
        object Next();
        bool IsDone();
        object CurrentItem();
    }
}
