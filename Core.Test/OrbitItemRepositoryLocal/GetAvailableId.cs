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
        public void ReturnsExpectedNumber_WhenFilled()
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

        [Fact]
        public void Range_ReturnsExpected_WhenEmpty()
        {
            const int amountOfNumbers = 3;
            int expectedStartNumber = 1;

            IEnumerable<int> results = sut.GetAvailableId(amountOfNumbers);

            foreach (int result in results)
            {
                Assert.Equal(expectedStartNumber, result);
                expectedStartNumber++;
            }
        }

        [Fact]
        public void Range_ReturnsExpectedNumbers_WhenFilled()
        {
            const int amountOfNumbers = 3;
            Populate();
            int expectedStartNumber = ContainedOrbitItems.Count + 1;

            IEnumerable<int> results = sut.GetAvailableId(amountOfNumbers);

            foreach (int result in results)
            {
                Assert.Equal(expectedStartNumber, result);
                expectedStartNumber++;
            }
        }

        [Fact]
        public void Range_ReturnsAvailableNumberAfterDeleting_WhenFilled()
        {
            const int amountOfNumbers = 3;
            Populate();
            int[] expected = { ContainingOrbiterTwo.Id, ContainingOrbiterSubSubOne.Id + 1, ContainingOrbiterSubSubOne.Id + 2 };
            sut.Delete(expected[0]);

            IEnumerable<int> results = sut.GetAvailableId(amountOfNumbers);

            int index = 0;
            foreach (int result in results)
            {
                Assert.Equal(expected[index], result);
                index++;
            }
        }
    }
}
