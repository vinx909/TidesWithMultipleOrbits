﻿using Entities = Core.Entities;
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
        protected ITideCalculator sut;

        protected Mock<IOrbitItemsRepository> mockItemsRepository;
        protected Mock<IWriter> mockWriter;

        protected Entities.OrbitItem SystemOneStar;
        protected Entities.OrbitItem SystemOneSataliteOne;
        protected Entities.OrbitItem SystemOneSataliteTwo;
        protected Entities.OrbitItem SystemTwoStar;
        protected Entities.OrbitItem SystemTwoSataliteOne;
        protected Entities.OrbitItem SystemTwoSataliteTwo;
        protected Entities.OrbitItem SystemTwoSubSatalite;

        protected IEnumerable<Entities.OrbitItem> SystemOneOrbitItems;
        protected IEnumerable<Entities.OrbitItem> SystemTwoOrbitItems;

        public TideCalculatorTestBase()
        {
            mockItemsRepository = new();
            mockWriter = new();

            sut = new Service.TideCalculator(mockItemsRepository.Object, mockWriter.Object);

            SystemOneStar = new() { Id = 1, Mass = 10000, Name = "Isosceles right triangle A", OrbitingId = 0, Radius = 1000 };
            SystemOneSataliteOne = new() { Id = 2, Mass = 100, Name = "Isosceles right triangle B", OrbitingId = 1, Radius = 10, OrbitingDistance = 10000, OrbitPeriod = 2 };
            SystemOneSataliteTwo = new() { Id = 3, Mass = 100, Name = "Isosceles right triangle C", OrbitingId = 1, Radius = 10, OrbitingDistance = 10000, OrbitPeriod = 4 };
            SystemTwoStar = new() { Id = 4, Mass = 10000, Name = "right triangle A", OrbitingId = 0, Radius = 1000, OrbitingDistance = 1000, OrbitPeriod = 12 };
            SystemTwoSataliteOne = new() { Id = 5, Mass = 100, Name = "right triangle B", OrbitingId = 4, Radius = 10, OrbitingDistance = 10000, OrbitPeriod = 2 };
            SystemTwoSataliteTwo = new() { Id = 6, Mass = 100, Name = "right triangle C", OrbitingId = 4, Radius = 10, OrbitingDistance = 20000, OrbitPeriod = 4 };
            SystemTwoSubSatalite = new() { Id = 7, Mass = 1, Name = "Rectangle", OrbitingId = 5, Radius = 1, OrbitingDistance = 10000, OrbitPeriod = 4 };

            SystemOneOrbitItems = new List<Entities.OrbitItem>() { SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo};
            SystemTwoOrbitItems = new List<Entities.OrbitItem>() { SystemTwoStar, SystemTwoSataliteOne, SystemTwoSataliteTwo, SystemTwoSubSatalite };
        }
    }
}
