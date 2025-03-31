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

            if (idAlreadyExists || !orbitingIdExists||Contains(item, false))
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

                        if (item.Name.Equals(otherItem.Name) && item.Mass == otherItem.Mass && item.Radius == otherItem.Radius && item.OrbitingDistance == otherItem.OrbitingDistance && item.OrbitPeriod == otherItem.OrbitPeriod)
                        {
                            return false;
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

                    if (item.Name.Equals(orbitItems[i].Name) && item.Mass == orbitItems[i].Mass && item.Radius == orbitItems[i].Radius && item.OrbitingDistance == orbitItems[i].OrbitingDistance && item.OrbitPeriod == orbitItems[i].OrbitPeriod)
                    {
                        return false;
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
            foreach (OrbitItem item in orbitItems)
            {
                if (item.Id == id)
                {
                    return item.OrbitingId;
                }
            }
            return null;
        }

        public int? ContainsWithOrbitingId(OrbitItem item)
        {
            foreach (var orbitItem in orbitItems)
            {
                if (
                    orbitItem.Name.Equals(item.Name) &&
                    orbitItem.Mass == item.Mass &&
                    orbitItem.Radius == item.Radius &&
                    orbitItem.OrbitingDistance == item.OrbitingDistance &&
                    orbitItem.OrbitPeriod == item.OrbitPeriod)
                {
                    return orbitItem.OrbitingId;
                }
            }

            return null;
        }

        public bool Delete(int id, bool update)
        {
            if (Contains(id))
            {
                return DeleteAction(Get(id), update);
            }
            else
            {
                return false;
            }
        }

        public bool Delete(OrbitItem item, bool update)
        {
            if(Contains(item, true))
            {
                return Delete(item.Id, update);
            }
            else
            {
                return false;
            }
        }

        private bool DeleteAction(OrbitItem item, bool update)
        {
            IEnumerable<OrbitItem> orbiters = GetAllOrbitersOf(item.Id, false);
            if (orbiters.Any())
            {
                if (update)
                {
                    foreach (OrbitItem orbiter in orbiters)
                    {
                        orbiter.OrbitingId = 0;
                    }
                    if (!Update(orbiters))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            orbitItems.Remove(item);
            return true;
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
            return new List<OrbitItem>(orbitItems);
        }

        public IEnumerable<OrbitItem> GetAllOrbitersOf(int id, bool getSuborbiters)
        {
            List<OrbitItem> toReturn = new();
            
            foreach (OrbitItem item in orbitItems)
            {
                if(item.OrbitingId == id)
                {
                    toReturn.Add(item);
                }
            }

            if( getSuborbiters)
            {
                for (int i = 0; i < toReturn.Count; i++)
                {
                    toReturn.AddRange(GetAllOrbitersOf(toReturn[i].Id, true));
                }
            }

            return toReturn;
        }

        public int GetAvailableId()
        {
            int id = 0;
            bool idFree = false;

            while (!idFree)
            {
                id++;
                idFree = true;
                foreach (OrbitItem item in orbitItems)
                {
                    if (item.Id == id)
                    {
                        idFree = false;
                        break;
                    }
                }
            }

            return id;
        }

        public IEnumerable<int> GetAvailableId(int amountOfNumbers)
        {
            List<int> toReturn = new();

            for (int i = 0; i < amountOfNumbers; i++)
            {
                int id;
                if (i == 0)
                {
                    id = 0;
                }
                else
                {
                    id = toReturn[i - 1];
                }

                bool idFree = false;

                while (!idFree)
                {
                    id++;
                    idFree = true;
                    foreach (OrbitItem item in orbitItems)
                    {
                        if (item.Id == id)
                        {
                            idFree = false;
                            break;
                        }
                    }
                }

                toReturn.Add(id);
            }

            return toReturn;
        }

        public int? GetIdOf(OrbitItem item, bool checkOrbitingId)
        {
            foreach (var orbitItem in orbitItems)
            {
                if (
                    orbitItem.Name.Equals(item.Name) &&
                    (!checkOrbitingId || orbitItem.OrbitingId == item.OrbitingId) &&
                    orbitItem.Mass == item.Mass &&
                    orbitItem.Radius == item.Radius &&
                    orbitItem.OrbitingDistance == item.OrbitingDistance &&
                    orbitItem.OrbitPeriod == item.OrbitPeriod)
                {
                    return orbitItem.Id;
                }
            }

            return null;
        }

        public bool Update(OrbitItem item)
        {
            //Id Exists
            if (!Contains(item.Id))
            {
                return false;
            }

            //OrbitingId is an Id that exists
            if (item.OrbitingId != 0 && Get(item.OrbitingId) == null)
            {
                return false;
            }

            // make sure there's no infinite orbit loop
            if (item.OrbitingId != 0)
            {
                if(InifiniteLoops(item.OrbitingId, item.Id))
                {
                    return false;
                }
            }

            //make sure it creates no ambiguity between values
            for (int i = 0; i < orbitItems.Count; i++)
            {
                if(item.Id != orbitItems[i].Id && item.Name.Equals(orbitItems[i].Name) && item.Mass == orbitItems[i].Mass && item.Radius == orbitItems[i].Radius && item.OrbitingDistance == orbitItems[i].OrbitingDistance && item.OrbitPeriod == orbitItems[i].OrbitPeriod)
                {
                    return false;
                }
            }

            DoUpdate(item);
            return true;
        }

        public bool Update(IEnumerable<OrbitItem> items)
        {
            foreach (OrbitItem item in items)
            {
                //Id Exists
                if (!Contains(item.Id))
                {
                    return false;
                }

                //OrbitingId is an Id that exists
                if (item.OrbitingId!=0 && Get(item.OrbitingId) == null)
                {
                    return false;
                }

                // make sure there's no infinite orbit loop
                if (item.OrbitingId != 0)
                {
                    if (InifiniteLoops(items, item.OrbitingId, item.Id))
                    {
                        return false;
                    }
                }

                //make sure there's no ambiguity between items
                foreach(OrbitItem otherItem in items)
                {
                    if (item.Id != otherItem.Id && item.Name.Equals(otherItem.Name) && item.Mass == otherItem.Mass && item.Radius == otherItem.Radius && item.OrbitingDistance == otherItem.OrbitingDistance && item.OrbitPeriod == otherItem.OrbitPeriod)
                    {
                        return false;
                    }
                }

                //make sure it creates no ambiguity between values
                for (int i = 0; i < orbitItems.Count; i++)
                {
                    if (item.Id != orbitItems[i].Id && item.Name.Equals(orbitItems[i].Name) && item.Mass == orbitItems[i].Mass && item.Radius == orbitItems[i].Radius && item.OrbitingDistance == orbitItems[i].OrbitingDistance && item.OrbitPeriod == orbitItems[i].OrbitPeriod)
                    {
                        return false;
                    }
                }
            }

            foreach (OrbitItem item in items)
            {
                DoUpdate(item); 
            }
            return true;
        }

        private void DoUpdate(OrbitItem item)
        {
            for (int i = 0; i < orbitItems.Count; i++)
            {
                if(orbitItems[i].Id == item.Id)
                {
                    orbitItems[i].Name = item.Name;
                    orbitItems[i].OrbitingId = item.OrbitingId;
                    orbitItems[i].Mass = item.Mass;
                    orbitItems[i].Radius = item.Radius;
                    orbitItems[i].OrbitingDistance = item.OrbitingDistance;
                    orbitItems[i].OrbitPeriod = item.OrbitPeriod;
                    return;
                }
            }
        }

        private bool InifiniteLoops(int currentId, int firstId)
        {
            OrbitItem toCheck = Get(currentId);
            if(toCheck.OrbitingId == firstId)
            {
                return true;
            }
            else if(toCheck.OrbitingId == 0)
            {
                return false;
            }
            else
            {
                return InifiniteLoops(toCheck.OrbitingId, firstId);
            }
        }

        private bool InifiniteLoops(IEnumerable<OrbitItem> Updated, int currentId, int firstId)
        {
            OrbitItem toCheck = null;
            foreach (OrbitItem item in Updated)
            {
                if (item.Id == currentId)
                {
                    toCheck = item; break;
                }
            }
            if (toCheck == null)
            {
                toCheck = Get(currentId);
            }

            if (toCheck.OrbitingId == firstId)
            {
                return true;
            }
            else if (toCheck.OrbitingId == 0)
            {
                return false;
            }
            else
            {
                return InifiniteLoops(toCheck.OrbitingId, firstId);
            }
        }
    }
}
