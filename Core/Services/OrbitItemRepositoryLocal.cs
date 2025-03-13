using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class OrbitItemRepositoryLocal : IOrbitItemsRepository
    {
        private readonly List<OrbitItem> orbitItems;

        public OrbitItemRepositoryLocal()
        {
            orbitItems = new();
        }

        public bool Add(OrbitItem item)
        {
            bool idAlreadyExists = false;
            bool orbitingIdExists = false;

            if(item.OrbitingId == 0)
            {
                orbitingIdExists = true;
            }

            for (int i = 0; i < orbitItems.Count; i++)
            {
                idAlreadyExists = idAlreadyExists || orbitItems[i].Id == item.Id;
                orbitingIdExists = orbitingIdExists || orbitItems[i].OrbitingId == item.OrbitingId;

                if(idAlreadyExists && orbitingIdExists)
                {
                    break;
                }
            }

            if (idAlreadyExists || !orbitingIdExists)
            {
                return false;
            }

            orbitItems.Add(item);
            return true;
        }

        public bool Add(IEnumerable<OrbitItem> items)
        {
            foreach (OrbitItem item in items)
            {
                bool idAlreadyExists = false;
                bool orbitingIdExists = false;

                if (item.OrbitingId == 0)
                {
                    orbitingIdExists = true;
                }

                foreach (OrbitItem otherItem in items)
                {
                    if(otherItem != item)
                    {
                        idAlreadyExists = idAlreadyExists || otherItem.Id == item.Id;
                        orbitingIdExists = orbitingIdExists || otherItem.Id == item.OrbitingId;

                        if (idAlreadyExists && orbitingIdExists)
                        {
                            break;
                        }
                    }
                }

                for (int i = 0; i < orbitItems.Count; i++)
                {
                    idAlreadyExists = idAlreadyExists || orbitItems[i].Id == item.Id;
                    orbitingIdExists = orbitingIdExists || orbitItems[i].Id == item.OrbitingId;

                    if (idAlreadyExists && orbitingIdExists)
                    {
                        break;
                    }
                }

                if (idAlreadyExists || !orbitingIdExists)
                {
                    return false;
                } 
            }

            foreach (OrbitItem item in items)
            {
                orbitItems.Add(item);
            }

            return true;
        }

        public bool Contains(int id)
        {
            foreach (OrbitItem item in orbitItems)
            {
                if (item.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Contains(OrbitItem item, bool checkOrbitingId)
        {
            foreach (var orbitItem in orbitItems)
            {
                if(
                    orbitItem.Name.Equals(item.Name) &&
                    (!checkOrbitingId || orbitItem.OrbitingId == item.OrbitingId) &&
                    orbitItem.Mass == item.Mass &&
                    orbitItem.Radius == item.Radius &&
                    orbitItem.OrbitingDistance == item.OrbitingDistance &&
                    orbitItem.OrbitPeriod == item.OrbitPeriod)
                {
                    return true;
                }
            }

            return false;
        }

        public int? ContainsWithOrbitingId(int id)
        {
            throw new NotImplementedException();
        }

        public int? ContainsWithOrbitingId(OrbitItem orbitItem)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id, bool update)
        {
            throw new NotImplementedException();
        }

        public bool Delete(OrbitItem item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(OrbitItem item, bool update)
        {
            throw new NotImplementedException();
        }

        public OrbitItem Get(int id)
        {
            foreach (OrbitItem item in orbitItems)
            {
                if(item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }

        public IEnumerable<OrbitItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrbitItem> GetAllOrbitersOf(int id, bool getSuborbiters)
        {
            throw new NotImplementedException();
        }

        public int GetAvailableId()
        {
            throw new NotImplementedException();
        }

        public int? GetIdOf(OrbitItem item, bool checkOrbitingId)
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
