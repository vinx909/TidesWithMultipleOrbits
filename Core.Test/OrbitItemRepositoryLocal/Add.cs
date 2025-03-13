using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.OrbitItemRepositoryLocal
{
    public class Add : OrbitItemRepositoryLocalTestBase
    {
        [Fact]
        public void ReturnsTrue_WhenAddingToEmpty()
        {
            bool result = sut.Add(NotContainingNotOrbiterTwo);
            
            Assert.True(result);
        }

        [Fact]
        public void GetReturnsItem_WhenAddingToEmpty()
        {
            Entities.OrbitItem target = NotContainingNotOrbiterTwo;

            sut.Add(target);
            var result = sut.Get(target.Id);

            Assert.Equal(target, result);
        }

        [Fact]
        public void ReturnsTrue_WhenAddingToFilled()
        {
            Populate();

            bool result = sut.Add(NotContainingNotOrbiterTwo);

            Assert.True(result);
        }

        [Fact]
        public void GetReturnsItem_WhenAddingToFilled()
        {
            Populate();
            Entities.OrbitItem target = NotContainingNotOrbiterTwo;

            sut.Add(target);
            var result = sut.Get(target.Id);

            Assert.Equal(target, result);
        }

        [Fact]
        public void ReturnsFalse_WhenAddingWithOrbiterIdThatDoesNotExist()
        {
            bool result = sut.Add(NotContainingOrbiterThree);

            Assert.False(result);
        }

        [Fact]
        public void GetReturnsNull_WhenAddingWithOrbiterIdThatDoesNotExist()
        {
            Entities.OrbitItem target = NotContainingOrbiterThree;

            sut.Add(target);
            var result = sut.Get(target.Id);

            Assert.Null(result);
        }

        [Fact]
        public void ReturnsFalse_WhenAddingWithIdThatAlreadyExists()
        {
            Populate();
            NotContainingOrbiterThree.Id = ContainingNotOrbiterOne.Id;

            bool result = sut.Add(NotContainingOrbiterThree);

            Assert.False(result);
        }

        [Fact]
        public void GetOrigional_WhenAddingWithIdThatAlreadyExists()
        {
            Populate();
            Entities.OrbitItem origional = ContainingNotOrbiterOne;
            NotContainingOrbiterThree.Id = origional.Id;

            sut.Add(NotContainingOrbiterThree);
            var result = sut.Get(origional.Id);

            Assert.Equal(origional, result);
        }

        [Fact]
        public void ReturnsTrue_WhenAddingMultipleToEmpty()
        {
            Entities.OrbitItem[] toAddList = { ContainingNotOrbiterOne, NotContainingNotOrbiterTwo };

            bool result = sut.Add(toAddList);

            Assert.True(result);
        }

        [Fact]
        public void GetReturnsItem_WhenAddingMultipleToEmpty()
        {
            Entities.OrbitItem[] toAddList = { ContainingNotOrbiterOne, NotContainingNotOrbiterTwo };
            Entities.OrbitItem[] resultList = new Entities.OrbitItem[toAddList.Length];

            sut.Add(toAddList);
            for (int i = 0; i < toAddList.Length; i++)
            {
                resultList[i] = sut.Get(toAddList[i].Id);
            }

            for (int i = 0; i < toAddList.Length; i++)
            {
                Assert.Equal(toAddList[i], resultList[i]);
            }
        }

        [Fact]
        public void ReturnsTrue_WhenAddingMultipleToFilled()
        {
            Populate();
            Entities.OrbitItem[] toAddList = { NotContainingNotOrbiterTwo, NotContainingOrbiterThree };

            bool result = sut.Add(toAddList);

            Assert.True(result);
        }

        [Fact]
        public void GetReturnsItem_WhenAddingMultipleToFilled()
        {
            Populate();
            Entities.OrbitItem[] toAddList = { NotContainingNotOrbiterTwo, NotContainingOrbiterThree };
            Entities.OrbitItem[] resultList = new Entities.OrbitItem[toAddList.Length];

            sut.Add(toAddList);
            for (int i = 0; i < toAddList.Length; i++)
            {
                resultList[i] = sut.Get(toAddList[i].Id);
            }

            for (int i = 0; i < toAddList.Length; i++)
            {
                Assert.Equal(toAddList[i], resultList[i]);
            }
        }

        [Fact]
        public void ReturnsFalse_WhenAddingMultipleWithOrbiterIdThatDoesNotExist()
        {
            Entities.OrbitItem[] toAddList = { NotContainingNotOrbiterTwo, NotContainingOrbiterThree };

            bool result = sut.Add(toAddList);

            Assert.False(result);
        }

        [Fact]
        public void GetReturnsNull_WhenAddingMultipleWithOrbiterIdThatDoesNotExist()
        {
            Entities.OrbitItem[] toAddList = { NotContainingNotOrbiterTwo, NotContainingOrbiterThree };
            Entities.OrbitItem[] resultList = new Entities.OrbitItem[toAddList.Length];

            sut.Add(toAddList);
            for (int i = 0; i < toAddList.Length; i++)
            {
                resultList[i] = sut.Get(toAddList[i].Id);
            }

            for (int i = 0; i < resultList.Length; i++)
            {
                Assert.Null(resultList[i]);
            }
        }

        [Theory]
        [InlineData(0, 1, 3, 6)]
        [InlineData(0, 1, 6, 3)]
        [InlineData(0, 3, 1, 6)]
        [InlineData(0, 3, 6, 1)]
        [InlineData(0, 6, 1, 3)]
        [InlineData(0, 6, 3, 1)]
        [InlineData(1, 0, 3, 6)]
        [InlineData(1, 0, 6, 3)]
        [InlineData(1, 3, 0, 6)]
        [InlineData(1, 3, 6, 0)]
        [InlineData(1, 6, 0, 3)]
        [InlineData(1, 6, 3, 0)]
        [InlineData(3, 0, 1, 6)]
        [InlineData(3, 0, 6, 1)]
        [InlineData(3, 1, 0, 6)]
        [InlineData(3, 1, 6, 0)]
        [InlineData(3, 6, 0, 1)]
        [InlineData(3, 6, 1, 0)]
        [InlineData(6, 0, 1, 3)]
        [InlineData(6, 0, 3, 1)]
        [InlineData(6, 1, 0, 3)]
        [InlineData(6, 1, 3, 0)]
        [InlineData(6, 3, 0, 1)]
        [InlineData(6, 3, 1, 0)]
        public void ReturnTrue_WhenAddingMultipleThatReferenceEachOtherInAnyOrder(int index1, int index2, int index3, int index4)
        {
            Entities.OrbitItem[] toAddList = { ContainedOrbitItems[index1], ContainedOrbitItems[index2], ContainedOrbitItems[index3], ContainedOrbitItems[index4] };

            bool result = sut.Add(toAddList);

            Assert.True(result);
        }

        [Theory]
        [InlineData(0, 1, 3, 6)]
        [InlineData(0, 1, 6, 3)]
        [InlineData(0, 3, 1, 6)]
        [InlineData(0, 3, 6, 1)]
        [InlineData(0, 6, 1, 3)]
        [InlineData(0, 6, 3, 1)]
        [InlineData(1, 0, 3, 6)]
        [InlineData(1, 0, 6, 3)]
        [InlineData(1, 3, 0, 6)]
        [InlineData(1, 3, 6, 0)]
        [InlineData(1, 6, 0, 3)]
        [InlineData(1, 6, 3, 0)]
        [InlineData(3, 0, 1, 6)]
        [InlineData(3, 0, 6, 1)]
        [InlineData(3, 1, 0, 6)]
        [InlineData(3, 1, 6, 0)]
        [InlineData(3, 6, 0, 1)]
        [InlineData(3, 6, 1, 0)]
        [InlineData(6, 0, 1, 3)]
        [InlineData(6, 0, 3, 1)]
        [InlineData(6, 1, 0, 3)]
        [InlineData(6, 1, 3, 0)]
        [InlineData(6, 3, 0, 1)]
        [InlineData(6, 3, 1, 0)]
        public void GetReturnsItem_WhenAddingMultipleThatReferenceEachOtherInAnyOrder(int index1, int index2, int index3, int index4)
        {
            Entities.OrbitItem[] toAddList = { ContainedOrbitItems[index1], ContainedOrbitItems[index2], ContainedOrbitItems[index3], ContainedOrbitItems[index4] };
            Entities.OrbitItem[] resultList = new Entities.OrbitItem[toAddList.Length];

            sut.Add(toAddList);
            for (int i = 0; i < toAddList.Length; i++)
            {
                resultList[i] = sut.Get(toAddList[i].Id);
            }

            for (int i = 0; i < toAddList.Length; i++)
            {
                Assert.Equal(toAddList[i], resultList[i]);
            }
        }

        [Fact]
        public void ReturnsFalse_WhenAddingMultipleWithIdThatAlreadyExists()
        {
            Populate();
            Entities.OrbitItem[] toAddList = { NotContainingNotOrbiterTwo, NotContainingOrbiterThree };
            toAddList[0].Id = ContainingNotOrbiterOne.Id;

            bool result = sut.Add(toAddList);

            Assert.False(result);
        }

        [Fact]
        public void GetOrigional_WhenAddingMultipleWithIdThatAlreadyExists()
        {
            Populate();
            Entities.OrbitItem[] toAddList = { NotContainingNotOrbiterTwo, NotContainingOrbiterThree };
            toAddList[0].Id = ContainingNotOrbiterOne.Id;
            Entities.OrbitItem[] resultList = new Entities.OrbitItem[toAddList.Length];

            sut.Add(toAddList);
            for (int i = 0; i < toAddList.Length; i++)
            {
                resultList[i] = sut.Get(toAddList[i].Id);
            }

            for (int i = 0; i < resultList.Length; i++)
            {
                Assert.Null(resultList[i]);
            }
        }
    }
}
