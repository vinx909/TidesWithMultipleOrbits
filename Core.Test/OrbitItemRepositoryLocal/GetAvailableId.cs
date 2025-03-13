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
        public void ReturnsOne_WhenEmpty()
        {
            int result = sut.GetAvailableId();

            Assert.Equal(1, result);
        }

        [Fact]
        public void ReturnsExpededNumber_WhenFilled()
        {
            Populate();
            int expected = ContainedOrbitItems.Count+1;

            int result = sut.GetAvailableId();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReturnsAvailableNumberAfterDeleting_WhenFilled()
        {
            Populate();
            int expected = ContainingOrbiterTwo.Id;
            sut.Delete(expected);

            int result = sut.GetAvailableId();

            Assert.Equal(expected, result);
        }
    }
}
