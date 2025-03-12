using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.OrbitItem
{
    public class Id : OrbitItemTestBase
    {
        [Fact]
        public void CanBeChangedToPossitiveInterger()
        {
            const int goalId = 5;

            sut.Id = goalId;

            Assert.Equal(goalId, sut.Id);
        }

        [Fact]
        public void CanNotBeChangedToNegativeInterger()
        {
            int origionalId = sut.Id;
            const int goalId = -5;

            sut.Id = goalId;

            Assert.Equal(origionalId, sut.Id);
        }

        [Fact]
        public void CanNotBeChangedToZero()
        {
            int origionalId = sut.Id;
            const int goalId = 0;

            sut.Id = goalId;

            Assert.Equal(origionalId, sut.Id);
        }
    }
}
