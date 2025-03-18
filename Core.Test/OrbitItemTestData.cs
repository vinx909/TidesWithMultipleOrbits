using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test
{
    public abstract class OrbitItemTestData
    {
        protected Entities.OrbitItem ContainingNotOrbiterOne;
        protected Entities.OrbitItem ContainingOrbiterOne;
        protected Entities.OrbitItem ContainingOrbiterTwo;
        protected Entities.OrbitItem ContainingOrbiterSubOne;
        protected Entities.OrbitItem ContainingOrbiterSubTwo;
        protected Entities.OrbitItem ContainingOrbiterSubSubOne;
        protected Entities.OrbitItem NotContainingNotOrbiterTwo;
        protected Entities.OrbitItem NotContainingOrbiterThree;
        protected Entities.OrbitItem NotContainingOrbiterSubThree;
        protected Entities.OrbitItem NotContainingOrbiterSubSubTwo;

        protected List<Entities.OrbitItem> ContainedOrbitItems;
        protected List<Entities.OrbitItem> NotContainedOrbitItems;

        protected OrbitItemTestData()
        {
            ContainingNotOrbiterOne = new() { Id = 1, Name = "star one", OrbitingId = 0, Mass = 5000, Radius = 1000 };
            ContainingOrbiterOne = new() { Id = 2, Name = "planet one", OrbitingId = 1, Mass = 500, Radius = 100, OrbitingDistance = 3000, OrbitPeriod = 300 };
            ContainingOrbiterTwo = new() { Id = 3, Name = "planet two", OrbitingId = 1, Mass = 400, Radius = 80, OrbitingDistance = 5000, OrbitPeriod = 500 };
            ContainingOrbiterSubOne = new() { Id = 4, Name = "moon one", OrbitingId = 2, Mass = 50, Radius = 10, OrbitingDistance = 300, OrbitPeriod = 30 };
            ContainingOrbiterSubTwo = new() { Id = 5, Name = "moon two", OrbitingId = 2, Mass = 40, Radius = 8, OrbitingDistance = 500, OrbitPeriod = 50 };
            ContainingOrbiterSubSubOne = new() { Id = 6, Name = "moonmoon one", OrbitingId = 4, Mass = 5, Radius = 2, OrbitingDistance = 30, OrbitPeriod = 4 };
            NotContainingNotOrbiterTwo = new() { Id = 7, Name = "star two", OrbitingId = 0, Mass = 7000, Radius = 1100 };
            NotContainingOrbiterThree = new() { Id = 8, Name = "planet three", OrbitingId = 1, Mass = 300, Radius = 70, OrbitingDistance = 7000, OrbitPeriod = 700 };
            NotContainingOrbiterSubThree = new() { Id = 9, Name = "moon three", OrbitingId = 2, Mass = 30, Radius = 6, OrbitingDistance = 600, OrbitPeriod = 75 };
            NotContainingOrbiterSubSubTwo = new() { Id = 10, Name = "moonmoon two", OrbitingId = 4, Mass = 4, Radius = 1, OrbitingDistance = 40, OrbitPeriod = 6 };

            ContainedOrbitItems = [ContainingNotOrbiterOne, ContainingOrbiterOne, ContainingOrbiterTwo, ContainingOrbiterSubOne, ContainingOrbiterSubTwo, ContainingOrbiterSubSubOne];
            NotContainedOrbitItems = [NotContainingNotOrbiterTwo, NotContainingOrbiterThree, NotContainingOrbiterSubThree, NotContainingOrbiterSubSubTwo];
        }

        protected static Entities.OrbitItem Copy(Entities.OrbitItem item)
        {
            return new Entities.OrbitItem() { Id = item.Id, Name = item.Name, OrbitingId = item.OrbitingId, Mass = item.Mass, Radius = item.Radius, OrbitingDistance = item.OrbitingDistance, OrbitPeriod = item.OrbitPeriod };
        }
    }
}
