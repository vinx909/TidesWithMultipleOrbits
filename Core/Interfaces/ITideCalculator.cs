using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITideCalculator
    {

        public bool AddRange(IEnumerable<OrbitItem> items);


        public bool AddItem(OrbitItem item);

        /// <summary>
        /// adds an item that is orbiting another item
        /// </summary>
        /// <param name="item">the item to add</param>
        /// <param name="orbitedItem">the item that it should orbit</param>
        /// <returns>return true if successful, false if not</returns>
        public bool AddItem(OrbitItem item, OrbitItem orbitedItem);
    }
}
