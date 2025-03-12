using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.OrbitItem
{
    public class Radius : OrbitItemTestBase
    {
        [Fact]
        public void CanBeChangedToPossitiveInterger()
        {
            const int goalValue = 5;

            sut.Radius = goalValue;

            Assert.Equal(goalValue, sut.Radius);
        }

        [Fact]
        public void CanNotBeChangedToNegativeInterger()
        {
            int origionalValue = sut.Radius;
            const int goalValue = -5;

            sut.Radius = goalValue;

            Assert.Equal(origionalValue, sut.Radius);
        }

        [Fact]
        public void CanBeChangedToZero()
        {
            const int goalValue = 0;

            sut.Radius = 1;
            sut.Radius = goalValue;

            Assert.Equal(goalValue, sut.Radius);
        }
    }
}
