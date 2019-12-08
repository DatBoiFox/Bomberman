using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Resources.Iterator
{
    public class MapItemIterator : Iterator
    {
        private MapItemRepository repository;

        public MapItemIterator(MapItemRepository repository)
        {
            this.repository = repository;
        }

        int index = 0;

        public object First()
        {
            index = 0;
            return repository[0];
        }

        public object Next()
        {
            if (index < repository.Count - 1)
            {
                return repository[++index];
            }

            return null;
        }

        public object CurrentItem()
        {
            return repository[index];
        }

        public bool IsDone()
        {
            return (index >= repository.Count);
        }

        public MapItemRepository GetMapItemRepository()
        {
            return repository;
        }
    }
}
