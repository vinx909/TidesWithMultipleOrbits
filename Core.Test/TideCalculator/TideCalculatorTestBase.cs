using Entities = Core.Entities;
using Service = Core.Services;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Core.Test.TideCalculator
{
    public class TideCalculatorTestBase
    {
        protected const double gravitationalConstant = 6.6743e-11;

        protected const double tolerance = 0.00000000001;
        protected const string path = "pathToFile";

        protected ITideCalculator sut;

        protected Mock<IOrbitItemsRepository> mockItemsRepository;
        protected Mock<IWriter> mockWriter;

        protected Entities.OrbitItem SystemOneStar;
        protected Entities.OrbitItem SystemOneSataliteOne;
        protected Entities.OrbitItem SystemOneSataliteTwo;
        protected Entities.OrbitItem SystemTwoStar;
        protected Entities.OrbitItem SystemTwoSataliteOne;
        protected Entities.OrbitItem SystemTwoSataliteTwo;
        protected Entities.OrbitItem SystemTwoSubSataliteOne;
        protected Entities.OrbitItem SystemTwoSubSataliteTwo;
        protected Entities.OrbitItem SystemTwoSubSubSatalite;

        protected IEnumerable<Entities.OrbitItem> SystemOneOrbitItems;
        protected IEnumerable<Entities.OrbitItem> SystemTwoOrbitItems;

        public TideCalculatorTestBase()
        {
            mockItemsRepository = new();
            mockWriter = new();

            sut = new Service.TideCalculator(mockItemsRepository.Object, mockWriter.Object);

            SystemOneStar = new() { Id = 1, Mass = 100000, Name = "Isosceles right triangle A", OrbitingId = 0, Radius = 10000 };
            SystemOneSataliteOne = new() { Id = 2, Mass = 1000, Name = "Isosceles right triangle B", OrbitingId = 1, Radius = 100, OrbitingDistance = 10000, OrbitPeriod = 2 };
            SystemOneSataliteTwo = new() { Id = 3, Mass = 1000, Name = "Isosceles right triangle C", OrbitingId = 1, Radius = 100, OrbitingDistance = 10000, OrbitPeriod = 4 };
            SystemTwoStar = new() { Id = 4, Mass = 100000, Name = "right triangle A", OrbitingId = 0, Radius = 10000 };
            SystemTwoSataliteOne = new() { Id = 5, Mass = 1000, Name = "right triangle B", OrbitingId = 4, Radius = 100, OrbitingDistance = 10000, OrbitPeriod = 4 };
            SystemTwoSataliteTwo = new() { Id = 6, Mass = 1000, Name = "right triangle C", OrbitingId = 4, Radius = 100, OrbitingDistance = 20000, OrbitPeriod = 2 };
            SystemTwoSubSataliteOne = new() { Id = 7, Mass = 10, Name = "rectangle", OrbitingId = 6, Radius = 10, OrbitingDistance = 10000, OrbitPeriod = 4 };
            SystemTwoSubSataliteTwo = new() { Id = 8, Mass = 10, Name = "rectangle mid point A", OrbitingId = 6, Radius = 10, OrbitingDistance = 1000, OrbitPeriod = 1 };
            SystemTwoSubSubSatalite = new() { Id = 9, Mass = 1, Name = "rectangle mid point B", OrbitingId = 7, Radius = 1, OrbitingDistance = 1000, OrbitPeriod = 1 };

            SystemOneOrbitItems = new List<Entities.OrbitItem>() { SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo};
            SystemTwoOrbitItems = new List<Entities.OrbitItem>() { SystemTwoStar, SystemTwoSataliteOne, SystemTwoSataliteTwo, SystemTwoSubSataliteOne, SystemTwoSubSataliteTwo, SystemTwoSubSubSatalite };
        }

        protected static double GetTidalForce(int excertingMass, int experiancerRadius, double distance)
        {
            return 2 * gravitationalConstant * excertingMass * experiancerRadius / Math.Pow(distance, 3);
        }

        protected static double GetTidalHeight(int excertingMass, int experiancerMass, int experiancerRadius, double distance)
        {
            return Math.Pow(experiancerRadius, 4) / Math.Pow(distance, 3) * excertingMass / experiancerMass;
        }
    }
}
