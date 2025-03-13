using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.OrbitItem
{
    public class OrbitingId : OrbitItemTestBase
    {
        [Fact]
        public void CanBeChangedToPossitiveInterger()
        {
            const int goalId = 5;

            sut.OrbitingId = goalId;

            Assert.Equal(goalId, sut.OrbitingId);
        }

        [Fact]
        public void CanNotBeChangedToNegativeInterger()
        {
            int origionalId = sut.OrbitingId;
            const int goalId = -5;

            sut.OrbitingId = goalId;

            Assert.Equal(origionalId, sut.OrbitingId);
        }

        [Fact]
        public void CanNotBeChangedToSameNumberAsId()
        {
            int origionalId = sut.OrbitingId;
            const int goalId = 5;
            sut.Id = goalId;

            sut.OrbitingId = goalId;

            Assert.Equal(origionalId, sut.OrbitingId);
        }

        [Fact]
        public void CanBeChangedToZero()
        {
            const int goalId = 0;

            sut.OrbitingId = 2;
            sut.OrbitingId = goalId;

            Assert.Equal(goalId, sut.OrbitingId);
        }

        [Fact]
        public void WhenSetToZeroOrbitingDistanceIsSetToZero()
        {
            const int goalId = 0;

            sut.OrbitingId = 2;
            sut.OrbitingDistance = 10;
            sut.OrbitingId = goalId;

            Assert.Equal(goalId, sut.OrbitingDistance);
        }

        [Fact]
        public void WhenSetToZeroOrbitPeriodIsSetToZero()
        {
            const int goalId = 0;

            sut.OrbitingId = 2;
            sut.OrbitPeriod = 10;
            sut.OrbitingId = goalId;

            Assert.Equal(goalId, sut.OrbitPeriod);
        }

        [Fact]
        public void WhenChangedFromZeroOrbitDistanceIsSetToOne()
        {
            sut.OrbitingId = 0;
            sut.OrbitPeriod = 0;
            sut.OrbitingId = 2;

            Assert.Equal(1, sut.OrbitingDistance);
        }
    }
}
