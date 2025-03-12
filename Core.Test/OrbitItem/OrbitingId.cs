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
        public void CanBeChangedToZero()
        {
            const int goalId = 0;

            sut.OrbitingId = 1;
            sut.OrbitingId = goalId;

            Assert.Equal(goalId, sut.OrbitingId);
        }
    }
}
