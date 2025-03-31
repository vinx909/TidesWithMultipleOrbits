using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.TideCalculator
{
    public class ProvideRangeToWorkWith : TideCalculatorTestBase
    {
        private static Entities.OrbitItem Copy(Entities.OrbitItem item)
        {
            return new Entities.OrbitItem() { Id = item.Id, Name = item.Name, OrbitingId = item.OrbitingId, Mass = item.Mass, Radius = item.Radius, OrbitingDistance = item.OrbitingDistance, OrbitPeriod = item.OrbitPeriod };
        }

        private static bool IsSame(Entities.OrbitItem itemOne, Entities.OrbitItem itemTwo)
        {
            return itemOne.Name.Equals(itemTwo.Name) && itemOne.Mass==itemTwo.Mass && itemOne.Radius == itemTwo.Radius && itemOne.OrbitingDistance == itemTwo.OrbitingDistance && itemOne.OrbitPeriod == itemTwo.OrbitPeriod;
        }

        [Fact]
        public void ReturnsTrue_IfRangeCorrect()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);

            var result = sut.ProvideRangeToWorkWith(SystemOneOrbitItems);

            Assert.True(result);
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryGetAll_IfRangeCorrect()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);

            sut.ProvideRangeToWorkWith(SystemOneOrbitItems);

            mockItemsRepository.Verify(m => m.GetAll());
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryDelete_IfIOrbitItemsRepositoryGetAllReturnsAnything_IfRangeCorrect()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);
            mockItemsRepository.Setup(m=>m.GetAll()).Returns(SystemTwoOrbitItems);
            mockItemsRepository.Setup(m => m.Delete(It.IsAny<Entities.OrbitItem>(), true)).Returns(true);

            sut.ProvideRangeToWorkWith(SystemOneOrbitItems);

            mockItemsRepository.Verify(m => m.Delete(It.IsAny<Entities.OrbitItem>(), true));
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryDeleteCorrectAmountOfTimes_IfIOrbitItemsRepositoryGetAllReturnsAnything_IfRangeCorrect()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemTwoOrbitItems);
            mockItemsRepository.Setup(m => m.Delete(It.IsAny<Entities.OrbitItem>(), true)).Returns(true);

            sut.ProvideRangeToWorkWith(SystemOneOrbitItems);

            mockItemsRepository.Verify(m => m.Delete(It.IsAny<Entities.OrbitItem>(), true), Times.Exactly(SystemTwoOrbitItems.Count()));
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryDeleteWithCorrectParameter_IfIOrbitItemsRepositoryGetAllReturnsAnything_IfRangeCorrect()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemTwoOrbitItems);
            mockItemsRepository.Setup(m => m.Delete(It.IsAny<Entities.OrbitItem>(), true)).Returns(true);

            sut.ProvideRangeToWorkWith(SystemOneOrbitItems);

            mockItemsRepository.Verify(m => m.Delete(SystemTwoStar, true));
            mockItemsRepository.Verify(m => m.Delete(SystemTwoSataliteOne, true));
            mockItemsRepository.Verify(m => m.Delete(SystemTwoSataliteTwo, true));
            mockItemsRepository.Verify(m => m.Delete(SystemTwoSubSataliteOne, true));
            mockItemsRepository.Verify(m => m.Delete(SystemTwoSubSataliteTwo, true));
            mockItemsRepository.Verify(m => m.Delete(SystemTwoSubSubSatalite, true));
        }

        [Fact]
        public void DoesNotInvokesIOrbitItemsRepositoryDelete_IfIOrbitItemsRepositoryGetAllReturnsNothing_IfRangeCorrect()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            mockItemsRepository.Setup(m => m.GetAll()).Returns([]);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);

            sut.ProvideRangeToWorkWith(SystemOneOrbitItems);

            mockItemsRepository.Verify(m => m.Delete(It.IsAny<Entities.OrbitItem>(), It.IsAny<bool>()), Times.Never());
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryGetAvailableId_IfRangeCorrect()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);

            sut.ProvideRangeToWorkWith(SystemOneOrbitItems);

            mockItemsRepository.Verify(m => m.GetAvailableId(3));
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryGetAvailableId_CorrectAmountOfTimes_IfRangeCorrect()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);

            sut.ProvideRangeToWorkWith(SystemOneOrbitItems);

            mockItemsRepository.Verify(m => m.GetAvailableId(3), Times.Once());
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryAdd_IfRangeCorrect()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);

            sut.ProvideRangeToWorkWith(SystemOneOrbitItems);

            mockItemsRepository.Verify(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>()));
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryAdd_CorrectAmountOfTimes_IfRangeCorrect()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);

            sut.ProvideRangeToWorkWith(SystemOneOrbitItems);

            mockItemsRepository.Verify(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>()), Times.Once());
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryAddWithCorrectParameter_IfRangeCorrect()
        {
            IEnumerable<Entities.OrbitItem> responce = null;
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true).Callback<IEnumerable<Entities.OrbitItem>>(r => responce = r);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);

            sut.ProvideRangeToWorkWith(SystemOneOrbitItems);

            foreach (var responceItem in responce)
            {
                bool matchFound = false;

                foreach (var entity in SystemOneOrbitItems)
                {
                    if(IsSame(responceItem, entity))
                    {
                        matchFound = true;
                        break;
                    }
                }

                Assert.True(matchFound);
            }
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryAddWithCorrectParameterReferences_IfRangeCorrect()
        {
            IEnumerable<Entities.OrbitItem> responce = null;
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true).Callback<IEnumerable<Entities.OrbitItem>>(r => responce = r);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);

            sut.ProvideRangeToWorkWith(SystemOneOrbitItems);

            foreach (var responceItem in responce)
            {
                bool matchFound = false;

                foreach (var origional in SystemOneOrbitItems)
                {
                    if (IsSame(responceItem, origional))
                    {
                        foreach (var referencedResponceItem in responce)
                        {
                            if(responceItem != referencedResponceItem && responceItem.OrbitingId == referencedResponceItem.Id)
                            {
                                foreach (var referencedorigional in SystemOneOrbitItems)
                                {
                                    if (origional != referencedorigional && origional.OrbitingId == referencedorigional.Id)
                                    {
                                        Assert.True(IsSame(referencedorigional, referencedResponceItem));
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        [Fact]
        public void ReturnsFalse_IfRangeHasNoOrbitZero()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);

            var result = sut.ProvideRangeToWorkWith([SystemOneSataliteOne, SystemOneSataliteTwo]);

            Assert.False(result);
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryGetAll_IfRangeHasNoOrbitZero()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);

            sut.ProvideRangeToWorkWith([SystemOneSataliteOne, SystemOneSataliteTwo]);

            mockItemsRepository.Verify(m => m.GetAll(), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryDelete_IfIOrbitItemsRepositoryGetAllReturnsAnything_IfRangeHasNoOrbitZero()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemTwoOrbitItems);

            sut.ProvideRangeToWorkWith([SystemOneSataliteOne, SystemOneSataliteTwo]);

            mockItemsRepository.Verify(m => m.Delete(It.IsAny<Entities.OrbitItem>()), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryAdd_IfRangeHasNoOrbitZero()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);

            sut.ProvideRangeToWorkWith([SystemOneSataliteOne, SystemOneSataliteTwo]); ;

            mockItemsRepository.Verify(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>()), Times.Never());
        }

        [Fact]
        public void ReturnsFalse_IfRangeHasMultipleOrbitZero()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);

            var result = sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, SystemTwoStar]);

            Assert.False(result);
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryGetAll_IfRangeHasMultipleOrbitZero()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, SystemTwoStar]);

            mockItemsRepository.Verify(m => m.GetAll(), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryDelete_IfIOrbitItemsRepositoryGetAllReturnsAnything_IfRangeHasMultipleOrbitZero()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemTwoOrbitItems);

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, SystemTwoStar]);

            mockItemsRepository.Verify(m => m.Delete(It.IsAny<Entities.OrbitItem>()), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryAdd_IfRangeHasMultipleOrbitZero()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, SystemTwoStar]);

            mockItemsRepository.Verify(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>()), Times.Never());
        }

        [Fact]
        public void ReturnsFalse_IfRangeHasInfiniteOrbitLoop()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);
            SystemOneSataliteOne.OrbitingId = SystemOneSataliteTwo.Id;
            SystemOneSataliteTwo.OrbitingId = SystemOneSataliteOne.Id;

            var result = sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo]);

            Assert.False(result);
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryGetAll_IfRangeHasInfiniteOrbitLoop()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);
            SystemOneSataliteOne.OrbitingId = SystemOneSataliteTwo.Id;
            SystemOneSataliteTwo.OrbitingId = SystemOneSataliteOne.Id;

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo]);

            mockItemsRepository.Verify(m => m.GetAll(), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryDelete_IfIOrbitItemsRepositoryGetAllReturnsAnything_IfRangeHasInfiniteOrbitLoop()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemTwoOrbitItems);
            SystemOneSataliteOne.OrbitingId = SystemOneSataliteTwo.Id;
            SystemOneSataliteTwo.OrbitingId = SystemOneSataliteOne.Id;

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo]);

            mockItemsRepository.Verify(m => m.Delete(It.IsAny<Entities.OrbitItem>()), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryAdd_IfRangeHasInfiniteOrbitLoop()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);
            SystemOneSataliteOne.OrbitingId = SystemOneSataliteTwo.Id;
            SystemOneSataliteTwo.OrbitingId = SystemOneSataliteOne.Id;

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo]);

            mockItemsRepository.Verify(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>()), Times.Never());
        }

        [Fact]
        public void ReturnsFalse_IfRangeHasItemOrbitingNonexistingItem()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);

            var result = sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, SystemTwoSubSataliteTwo]);

            Assert.False(result);
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryGetAll_IfRangeHasItemOrbitingNonexistingItem()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, SystemTwoSubSataliteTwo]);

            mockItemsRepository.Verify(m => m.GetAll(), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryDelete_IfIOrbitItemsRepositoryGetAllReturnsAnything_IfRangeHasItemOrbitingNonexistingItem()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemTwoOrbitItems);

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, SystemTwoSubSataliteTwo]);

            mockItemsRepository.Verify(m => m.Delete(It.IsAny<Entities.OrbitItem>()), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryAdd_IfRangeHasItemOrbitingNonexistingItem()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, SystemTwoSubSataliteTwo]);

            mockItemsRepository.Verify(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>()), Times.Never());
        }

        [Fact]
        public void ReturnsFalse_IfRangeHasItemWithSameId()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);
            SystemOneSataliteTwo.Id = SystemOneSataliteOne.Id;

            var result = sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo]);

            Assert.False(result);
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryGetAll_IfRangeHasItemWithSameId()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);
            SystemOneSataliteTwo.Id = SystemOneSataliteOne.Id;

            var result = sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo]);

            mockItemsRepository.Verify(m => m.GetAll(), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryDelete_IfIOrbitItemsRepositoryGetAllReturnsAnything_IfRangeHasItemWithSameId()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemTwoOrbitItems);
            SystemOneSataliteTwo.Id = SystemOneSataliteOne.Id;

            var result = sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo]);

            mockItemsRepository.Verify(m => m.Delete(It.IsAny<Entities.OrbitItem>()), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryAdd_IfRangeHasItemWithSameId()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);
            SystemOneSataliteTwo.Id = SystemOneSataliteOne.Id;

            var result = sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo]);

            mockItemsRepository.Verify(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>()), Times.Never());
        }

        [Fact]
        public void ReturnsFalse_IfRangeHasItemWithSameValuesExceptIdAndOrbitingId()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);
            Entities.OrbitItem copy = Copy(SystemOneSataliteTwo);
            copy.Id += 10;
            copy.OrbitingId = SystemOneSataliteTwo.Id;

            var result = sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, copy]);

            Assert.False(result);
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryGetAll_IfRangeHasItemWithSameValuesExceptIdAndOrbitingId()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);
            Entities.OrbitItem copy = Copy(SystemOneSataliteTwo);
            copy.Id += 10;
            copy.OrbitingId = SystemOneSataliteTwo.Id;

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, copy]);

            mockItemsRepository.Verify(m => m.GetAll(), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryDelete_IfIOrbitItemsRepositoryGetAllReturnsAnything_IfRangeHasItemWithSameValuesExceptIdAndOrbitingId()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemTwoOrbitItems);
            Entities.OrbitItem copy = Copy(SystemOneSataliteTwo);
            copy.Id += 10;
            copy.OrbitingId = SystemOneSataliteTwo.Id;

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, copy]);

            mockItemsRepository.Verify(m => m.Delete(It.IsAny<Entities.OrbitItem>()), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryAdd_IfRangeHasItemWithSameValuesExceptIdAndOrbitingId()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);
            Entities.OrbitItem copy = Copy(SystemOneSataliteTwo);
            copy.Id += 10;
            copy.OrbitingId = SystemOneSataliteTwo.Id;

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, copy]);

            mockItemsRepository.Verify(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>()), Times.Never());
        }

        [Fact]
        public void ReturnsFalse_IfRangeHasItemWithSameValuesExceptId()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);
            Entities.OrbitItem copy = Copy(SystemOneSataliteTwo);
            copy.Id += 10;

            var result = sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, copy]);

            Assert.False(result);
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryGetAll_IfRangeHasItemWithSameValuesExceptId()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);
            Entities.OrbitItem copy = Copy(SystemOneSataliteTwo);
            copy.Id += 10;

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, copy]);

            mockItemsRepository.Verify(m => m.GetAll(), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryDelete_IfIOrbitItemsRepositoryGetAllReturnsAnything_IfRangeHasItemWithSameValuesExceptId()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemTwoOrbitItems);
            Entities.OrbitItem copy = Copy(SystemOneSataliteTwo);
            copy.Id += 10;

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, copy]);

            mockItemsRepository.Verify(m => m.Delete(It.IsAny<Entities.OrbitItem>()), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryAdd_IfRangeHasItemWithSameValuesExceptId()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);
            Entities.OrbitItem copy = Copy(SystemOneSataliteTwo);
            copy.Id += 10;

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, copy]);

            mockItemsRepository.Verify(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>()), Times.Never());
        }

        [Fact]
        public void ReturnsFalse_IfIOrbitItemsRepositoryGetAllReturnsAnything_IfIOrbitItemsRepositoryDeleteReturnsFalse()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(false);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemTwoOrbitItems);
            mockItemsRepository.Setup(m => m.Delete(It.IsAny<Entities.OrbitItem>())).Returns(false);

            var result = sut.ProvideRangeToWorkWith(SystemOneOrbitItems);

            Assert.False(result);
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryAdd_IfIOrbitItemsRepositoryGetAllReturnsAnything_IfIOrbitItemsRepositoryDeleteReturnsFalse()
        {
            mockItemsRepository.Setup(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>())).Returns(true);
            mockItemsRepository.Setup(m => m.GetAvailableId(3)).Returns([1,2,3]);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemTwoOrbitItems);
            mockItemsRepository.Setup(m => m.Delete(It.IsAny<Entities.OrbitItem>())).Returns(false);

            try
            {
                sut.ProvideRangeToWorkWith(SystemOneOrbitItems);
            }
            catch (Exception ex) { }
            

            mockItemsRepository.Verify(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>()), Times.Never());
        }
    }
}
