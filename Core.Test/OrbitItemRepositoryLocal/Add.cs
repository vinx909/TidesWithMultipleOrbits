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
        [InlineData(0, 1, 3, 5)]
        [InlineData(0, 1, 5, 3)]
        [InlineData(0, 3, 1, 5)]
        [InlineData(0, 3, 5, 1)]
        [InlineData(0, 5, 1, 3)]
        [InlineData(0, 5, 3, 1)]
        [InlineData(1, 0, 3, 5)]
        [InlineData(1, 0, 5, 3)]
        [InlineData(1, 3, 0, 5)]
        [InlineData(1, 3, 5, 0)]
        [InlineData(1, 5, 0, 3)]
        [InlineData(1, 5, 3, 0)]
        [InlineData(3, 0, 1, 5)]
        [InlineData(3, 0, 5, 1)]
        [InlineData(3, 1, 0, 5)]
        [InlineData(3, 1, 5, 0)]
        [InlineData(3, 5, 0, 1)]
        [InlineData(3, 5, 1, 0)]
        [InlineData(5, 0, 1, 3)]
        [InlineData(5, 0, 3, 1)]
        [InlineData(5, 1, 0, 3)]
        [InlineData(5, 1, 3, 0)]
        [InlineData(5, 3, 0, 1)]
        [InlineData(5, 3, 1, 0)]
        public void ReturnTrue_WhenAddingMultipleThatReferenceEachOtherInAnyOrder(int index1, int index2, int index3, int index4)
        {
            Entities.OrbitItem[] toAddList = { ContainedOrbitItems[index1], ContainedOrbitItems[index2], ContainedOrbitItems[index3], ContainedOrbitItems[index4] };

            bool result = sut.Add(toAddList);

            Assert.True(result);
        }

        [Theory]
        [InlineData(0, 1, 3, 5)]
        [InlineData(0, 1, 5, 3)]
        [InlineData(0, 3, 1, 5)]
        [InlineData(0, 3, 5, 1)]
        [InlineData(0, 5, 1, 3)]
        [InlineData(0, 5, 3, 1)]
        [InlineData(1, 0, 3, 5)]
        [InlineData(1, 0, 5, 3)]
        [InlineData(1, 3, 0, 5)]
        [InlineData(1, 3, 5, 0)]
        [InlineData(1, 5, 0, 3)]
        [InlineData(1, 5, 3, 0)]
        [InlineData(3, 0, 1, 5)]
        [InlineData(3, 0, 5, 1)]
        [InlineData(3, 1, 0, 5)]
        [InlineData(3, 1, 5, 0)]
        [InlineData(3, 5, 0, 1)]
        [InlineData(3, 5, 1, 0)]
        [InlineData(5, 0, 1, 3)]
        [InlineData(5, 0, 3, 1)]
        [InlineData(5, 1, 0, 3)]
        [InlineData(5, 1, 3, 0)]
        [InlineData(5, 3, 0, 1)]
        [InlineData(5, 3, 1, 0)]
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
            Entities.OrbitItem origional = ContainingNotOrbiterOne;
            toAddList[0].Id = origional.Id;

            sut.Add(toAddList);
            Entities.OrbitItem result = sut.Get(toAddList[0].Id);

            Assert.Equal(origional, result);
        }

        [Fact]
        public void ReturnsFalse_WhenAddingMultipleWithSameId()
        {
            const int id = 40;
            Entities.OrbitItem[] toAddList = { Copy(ContainingNotOrbiterOne), Copy(NotContainingNotOrbiterTwo) };
            toAddList[0].Id = id;
            toAddList[1].Id = id;

            bool result = sut.Add(toAddList);

            Assert.False(result);
        }

        [Fact]
        public void GetReturnsNull_WhenAddingMultipleWithSameId()
        {
            const int id = 40;
            Entities.OrbitItem[] toAddList = { Copy(ContainingNotOrbiterOne), Copy(NotContainingNotOrbiterTwo) };
            toAddList[0].Id = id;
            toAddList[1].Id = id;
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

        [Fact]
        public void ReturnsFalse_WhenAddingItemWithSameValuesOnlyDifferentIdAndOrbitingId()
        {
            sut.Add(ContainingNotOrbiterOne);
            var copy = Copy(ContainingNotOrbiterOne);
            copy.Id = 2;
            copy.OrbitingId = 1;

            bool result = sut.Add(copy);

            Assert.False(result);
        }

        [Fact]
        public void GetReturnsNull_WhenAddingItemWithSameValuesOnlyDifferentIdAndOrbitingId()
        {
            sut.Add(ContainingNotOrbiterOne);
            var copy = Copy(ContainingNotOrbiterOne);
            copy.Id = 2;
            copy.OrbitingId = 1;

            sut.Add(copy);
            var result = sut.Get(copy.Id);

            Assert.Null(result);
        }

        [Fact]
        public void ReturnsFalse_WhenAddingItemWithSameValuesOnlyDifferentId()
        {
            sut.Add(ContainingNotOrbiterOne);
            var copy = Copy(ContainingNotOrbiterOne);
            copy.Id = 2;

            bool result = sut.Add(copy);

            Assert.False(result);
        }

        [Fact]
        public void GetReturnsNull_WhenAddingItemWithSameValuesOnlyDifferentId()
        {
            sut.Add(ContainingNotOrbiterOne);
            var copy = Copy(ContainingNotOrbiterOne);
            copy.Id = 2;

            sut.Add(copy);
            var result = sut.Get(copy.Id);

            Assert.Null(result);
        }

        [Fact]
        public void ReturnsFalse_WhenAddingEnumerableItemWithSameValuesOnlyDifferentIdAndOrbitingId()
        {
            sut.Add([ContainingNotOrbiterOne, ContainingOrbiterOne]);
            var copy = Copy(ContainingOrbiterOne);
            copy.Id = 3;
            copy.OrbitingId = 2;

            bool result = sut.Add([copy]);

            Assert.False(result);
        }

        [Fact]
        public void GetReturnsNull_WhenAddingEnumerableItemWithSameValuesOnlyDifferentIdAndOrbitingId()
        {
            sut.Add([ContainingNotOrbiterOne, ContainingOrbiterOne]);
            var copy = Copy(ContainingOrbiterOne);
            copy.Id = 3;
            copy.OrbitingId = 2;

            sut.Add([copy]);
            var result = sut.Get(copy.Id);

            Assert.Null(result);
        }

        [Fact]
        public void ReturnsFalse_WhenAddingEnumerableItemWithSameValuesOnlyDifferentId()
        {
            sut.Add([ContainingNotOrbiterOne]);
            var copy = Copy(ContainingNotOrbiterOne);
            copy.Id = 2;

            bool result = sut.Add([copy]);

            Assert.False(result);
        }

        [Fact]
        public void GetReturnsNull_WhenAddingEnumerableItemWithSameValuesOnlyDifferentId()
        {
            sut.Add([ContainingNotOrbiterOne]);
            var copy = Copy(ContainingNotOrbiterOne);
            copy.Id = 2;

            sut.Add([copy]);
            var result = sut.Get(copy.Id);

            Assert.Null(result);
        }

        [Fact]
        public void ReturnsFalse_WhenAddingMultipelItemsWithSameValuesOnlyDifferentIdAndOrbitingId()
        {
            sut.Add([ContainingNotOrbiterOne]);
            var copy = Copy(ContainingOrbiterOne);
            copy.Id = 3;
            copy.OrbitingId = 2;

            bool result = sut.Add([ContainingOrbiterOne, copy]);

            Assert.False(result);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void GetReturnsNullForEither_WhenAddingMultipelItemsWithSameValuesOnlyDifferentIdAndOrbitingId(int id)
        {
            sut.Add([ContainingNotOrbiterOne]);
            var copy = Copy(ContainingOrbiterOne);
            copy.Id = 3;
            copy.OrbitingId = 2;

            sut.Add([ContainingOrbiterOne, copy]);
            var result = sut.Get(id);

            Assert.Null(result);
        }

        [Fact]
        public void ReturnsFalse_WhenAddingMultipelItemsWithSameValuesOnlyDifferentId()
        {
            var copy = Copy(ContainingNotOrbiterOne);
            copy.Id = 2;

            bool result = sut.Add([ContainingNotOrbiterOne, copy]);

            Assert.False(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void GetReturnsNullForEither_WhenAddingMultipelItemsWithSameValuesOnlyDifferentId(int id)
        {
            var copy = Copy(ContainingNotOrbiterOne);
            copy.Id = 2;

            sut.Add([ContainingNotOrbiterOne, copy]);
            var result = sut.Get(id);

            Assert.Null(result);
        }
    }
}
