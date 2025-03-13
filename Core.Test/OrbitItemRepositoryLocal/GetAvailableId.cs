using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.OrbitItemRepositoryLocal
{
    public class GetAvailableId : OrbitItemRepositoryLocalTestBase
    {
        [Fact]
        public void ReturnsZero_WhenEmpty()
        {
            int result = sut.GetAvailableId();

            Assert.Equal(0, result);
        }

        [Fact]
        public void ReturnsExpededNumber_WhenFilled()
        {
            Populate();
            int expected = ContainedOrbitItems.Count;

            int result = sut.GetAvailableId();

            Assert.Equal(0, result);
        }

        [Fact]
        public void ReturnsAvailableNumberAfterDeleting_WhenFilled()
        {
            Populate();
            int expected = ContainingOrbiterTwo.Id;
            sut.Delete(expected);

            int result = sut.GetAvailableId();

            Assert.Equal(0, result);
        }
    }
}
