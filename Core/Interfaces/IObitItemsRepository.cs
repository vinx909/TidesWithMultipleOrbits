using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IObitItemsRepository
    {
        /// <summary>
        /// adds the given item
        /// </summary>
        /// <param name="item"></param>
        /// <returns>returns true if the item was added or false if not</returns>
        public bool Add(OrbitItem item);

        /// <summary>
        /// adds the given items
        /// </summary>
        /// <param name="items"></param>
        /// <returns>returns true if the items was added or false if none were</returns>
        public bool Add(IEnumerable<OrbitItem> items);

        /// <summary>
        /// returns true if it contains an item with the given id;
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Contains(int id);

        /// <summary>
        /// returns true if it contains an item matching an item with these values ignoring id
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(OrbitItem item);

        /// <summary>
        /// returns the OrbitingId of an item matching an item with these values ignoring id, or null if such an item does not exist
        /// </summary>
        /// <param name="orbitItem"></param>
        /// <returns></returns>
        public int? ContainsWithOrbitingId(OrbitItem orbitItem);

        /// <summary>
        /// deletes the item with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns true if the item was deleted or false if not</returns>
        public bool Delete(int id);

        /// <summary>
        /// deletes an item that exactly matches the given item
        /// </summary>
        /// <param name="item"></param>
        /// <returns>returns true if the items were deleted or false if none were</returns>
        public bool Delete(OrbitItem item);

        /// <summary>
        /// returns the item with the given id, or null if it doesn't exist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrbitItem Get(int id);

        /// <summary>
        /// returns all items
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrbitItem> GetAll();

        /// <summary>
        /// returns all items that have the given id as OrbitingId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<OrbitItem> GetAllOrbitersOf(int id)
        {
            return GetAllOrbitersOf(id, true);
        }

        /// <summary>
        /// returns all items that have the given id as OrbitingId, with or without any suborbiters
        /// </summary>
        /// <param name="id">the id of the item to get all orbiters of</param>
        /// <param name="getSuborbiters">true to also get all items that orbit items that orbit the id and deeper, false to only get the items that directly orbit the given id</param>
        /// <returns></returns>
        public IEnumerable<OrbitItem> GetAllOrbitersOf(int id, bool getSuborbiters);

        /// <summary>
        /// updates the item that matches the id of the given item
        /// </summary>
        /// <param name="item"></param>
        /// <returns>returns true if the item was updated or was already up to date or false if it was not</returns>
        public bool Update(OrbitItem item);

        /// <summary>
        /// updates the items that matches the id of the given items
        /// </summary>
        /// <param name="items"></param>
        /// <returns>returns true if the items were updated or were already up to date or false if it was not</returns>
        public bool Update(IEnumerable<OrbitItem> items);
    }
}
