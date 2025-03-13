using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.OrbitItem
{
    public class OrbitPeriod : OrbitItemTestBase
    {
        [Fact]
        public void CanBeChangedToPossitiveInterger()
        {
            const int goalValue = 5;

            sut.OrbitPeriod = goalValue;

            Assert.Equal(goalValue, sut.OrbitPeriod);
        }

        [Fact]
        public void CanNotBeChangedToNegativeInterger()
        {
            int origionalValue = sut.OrbitPeriod;
            const int goalValue = -5;

            sut.OrbitPeriod = goalValue;

            Assert.Equal(origionalValue, sut.OrbitPeriod);
        }

        [Fact]
        public void CanBeChangedToZero()
        {
            const int goalValue = 0;

            sut.OrbitPeriod = 1;
            sut.OrbitPeriod = goalValue;

            Assert.Equal(goalValue, sut.OrbitPeriod);
        }

        [Fact]
        public void CanNotBeChangedFromZeroWhenOrbitingIdZero()
        {
            const int goalValue = 5;

            sut.OrbitingId = 0;
            sut.OrbitPeriod = goalValue;

            Assert.Equal(0, sut.OrbitPeriod);
        }
    }
}
