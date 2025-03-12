using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.OrbitItem
{
    public class Mass : OrbitItemTestBase
    {
        [Fact]
        public void CanBeChangedToPossitiveInterger()
        {
            const int goalValue = 5;

            sut.Mass = goalValue;

            Assert.Equal(goalValue, sut.Mass);
        }

        [Fact]
        public void CanNotBeChangedToNegativeInterger()
        {
            int origionalValue = sut.Mass;
            const int goalValue = -5;

            sut.Mass = goalValue;

            Assert.Equal(origionalValue, sut.Mass);
        }

        [Fact]
        public void CanBeChangedToZero()
        {
            const int goalValue = 0;

            sut.Mass = 1;
            sut.Mass = goalValue;

            Assert.Equal(goalValue, sut.Mass);
        }
    }
}
