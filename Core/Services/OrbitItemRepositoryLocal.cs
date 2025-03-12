using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class OrbitItemRepositoryLocal : IObitItemsRepository
    {
        public bool Add(OrbitItem item)
        {
            throw new NotImplementedException();
        }

        public bool Add(IEnumerable<OrbitItem> items)
        {
            throw new NotImplementedException();
        }

        public bool Contains(int id)
        {
            throw new NotImplementedException();
        }

        public bool Contains(OrbitItem item)
        {
            throw new NotImplementedException();
        }

        public int? ContainsWithOrbitingId(OrbitItem orbitItem)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(OrbitItem item)
        {
            throw new NotImplementedException();
        }

        public OrbitItem Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrbitItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrbitItem> GetAllOrbitersOf(int id, bool getSuborbiters)
        {
            throw new NotImplementedException();
        }

        public bool Update(OrbitItem item)
        {
            throw new NotImplementedException();
        }

        public bool Update(IEnumerable<OrbitItem> items)
        {
            throw new NotImplementedException();
        }
    }
}
