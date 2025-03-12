using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.OrbitItemRepositoryLocal
{
    public class GetAll : OrbitItemRepositoryLocalTestBase
    {
        [Fact]
        public void ReturnsNotNullIfEmpty()
        {
            var result = sut.GetAll();

            Assert.NotNull(result);
        }

        [Fact]
        public void ReturnsIEnumerableIfEmpty()
        {
            var result = sut.GetAll();

            Assert.IsAssignableFrom<IEnumerable<Entities.OrbitItem>>(result);
        }

        [Fact]
        public void ReturnsEmptyIEnumerableIfEmpty()
        {
            IEnumerable<Entities.OrbitItem> result = sut.GetAll();

            Assert.Empty(result);
        }

        [Fact]
        public void ReturnsNotNullIfPopulated()
        {
            Populate();

            var result = sut.GetAll();

            Assert.NotNull(result);
        }

        [Fact]
        public void ReturnsIEnumerableIfPopulated()
        {
            Populate();

            var result = sut.GetAll();

            Assert.IsAssignableFrom<IEnumerable<Entities.OrbitItem>>(result);
        }

        [Fact]
        public void ReturnsFilledIEnumerableIfPopulated()
        {
            Populate();

            IEnumerable<Entities.OrbitItem> result = sut.GetAll();

            Assert.NotEmpty(result);
        }

        [Fact]
        public void ReturnsCorrectAmountIfPopulated()
        {
            Populate();

            IEnumerable<Entities.OrbitItem> result = sut.GetAll();

            Assert.Equal(ContainedOrbitItems.Count(), result.Count());
        }

        [Fact]
        public void ReturnsCorrectItemsIfPopulated()
        {
            Populate();

            IEnumerable<Entities.OrbitItem> result = sut.GetAll();

            Assert.Equal(ContainedOrbitItems, result);
        }

        [Fact]
        public void ReturnsNoIncorrectItemsIfPopulated()
        {
            Populate();

            IEnumerable<Entities.OrbitItem> result = sut.GetAll();

            foreach (Entities.OrbitItem item in result)
            {
                Assert.Contains(item, ContainedOrbitItems); //every item from GetAll() should exist in ContainedOrbitItems, if it contains an item not from there something is wrong.
            }
        }
    }
}
