using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.OrbitItemRepositoryLocal
{
    public class Get : OrbitItemRepositoryLocalTestBase
    {
        [Fact]
        public void ReturnsNull_IfEmpty()
        {
            Entities.OrbitItem result = sut.Get(ContainingNotOrbiterOne.Id);

            Assert.Null(result);
        }

        [Fact]
        public void ReturnsNotNull_IfContaining()
        {
            Populate();

            Entities.OrbitItem result = sut.Get(ContainingNotOrbiterOne.Id);

            Assert.NotNull(result);
        }

        [Fact]
        public void ReturnsCorrectItem_IfContaining()
        {
            Populate();
            Entities.OrbitItem goal = ContainingNotOrbiterOne;

            Entities.OrbitItem result = sut.Get(goal.Id);

            Assert.Equal(goal, result);
        }

        [Fact]
        public void ReturnsNull_IfNotContainingWhenFilled()
        {
            Populate();

            Entities.OrbitItem result = sut.Get(NotContainingNotOrbiterTwo.Id);

            Assert.Null(result);
        }
    }
}
