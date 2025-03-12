using Entities = Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.OrbitItem
{
    public class Constructor
    {
        [Fact]
        public void CanConstruct()
        {
            var sut = new Entities.OrbitItem();

            Assert.IsType<Entities.OrbitItem>(sut);
        }

        [Fact]
        public void DefaultIdIsOne()
        {
            //arrange
            Entities.OrbitItem sut = new();

            //assert
            Assert.Equal(1, sut.Id);
        }

        [Fact]
        public void DefaultNameIsEmptyString()
        {

            //arrange
            Entities.OrbitItem sut = new();

            //assert
            Assert.Equal(string.Empty, sut.Name);
        }

        [Fact]
        public void DefaultOrbitingIdIsZero()
        {
            Entities.OrbitItem sut = new();

            Assert.Equal(0, sut.OrbitingId);
        }

        [Fact]
        public void DefaultMassIsZero()
        {
            Entities.OrbitItem sut = new();

            Assert.Equal(0, sut.Mass);
        }

        [Fact]
        public void DefaultRadiusIsZero()
        {
            Entities.OrbitItem sut = new();

            Assert.Equal(0, sut.Radius);
        }

        [Fact]
        public void DefaultOrbitDistanceisOne()
        {
            Entities.OrbitItem sut = new();

            Assert.Equal(1, sut.OrbitingDistance);
        }

        [Fact]
        public void DefaultOrbitPeriodIsZero()
        {
            Entities.OrbitItem sut = new();

            Assert.Equal(0, sut.OrbitPeriod);
        }
    }
}
