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

        [Fact]
        public void ReturnsTrue_IfRangeCorrect()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);

            var result = sut.ProvideRangeToWorkWith(SystemOneOrbitItems);

            Assert.True(result);
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryGetAll_IfRangeCorrect()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);

            sut.ProvideRangeToWorkWith(SystemOneOrbitItems);

            mockItemsRepository.Verify(m => m.GetAll());
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryDelete_IfIOrbitItemsRepositoryGetAllReturnsAnything_IfRangeCorrect()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            mockItemsRepository.Setup(m=>m.GetAll()).Returns(SystemTwoOrbitItems);

            sut.ProvideRangeToWorkWith(SystemOneOrbitItems);

            mockItemsRepository.Verify(m => m.Delete(It.IsAny<Entities.OrbitItem>()));
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryDeleteCorrectAmountOfTimes_IfIOrbitItemsRepositoryGetAllReturnsAnything_IfRangeCorrect()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemTwoOrbitItems);

            sut.ProvideRangeToWorkWith(SystemOneOrbitItems);

            mockItemsRepository.Verify(m => m.Delete(It.IsAny<Entities.OrbitItem>()), Times.Exactly(SystemTwoOrbitItems.Count()));
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryDeleteWithCorrectParameter_IfIOrbitItemsRepositoryGetAllReturnsAnything_IfRangeCorrect()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemTwoOrbitItems);

            sut.ProvideRangeToWorkWith(SystemOneOrbitItems);

            mockItemsRepository.Verify(m => m.Delete(SystemTwoStar));
            mockItemsRepository.Verify(m => m.Delete(SystemTwoSataliteOne));
            mockItemsRepository.Verify(m => m.Delete(SystemTwoSataliteTwo));
            mockItemsRepository.Verify(m => m.Delete(SystemTwoSubSataliteOne));
            mockItemsRepository.Verify(m => m.Delete(SystemTwoSubSataliteTwo));
            mockItemsRepository.Verify(m => m.Delete(SystemTwoSubSubSatalite));
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryAdd_IfRangeCorrect()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            sut.ProvideRangeToWorkWith(SystemOneOrbitItems);

            mockItemsRepository.Verify(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>()));
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryAddCorrectAmountOfTimes_IfRangeCorrect()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            sut.ProvideRangeToWorkWith(SystemOneOrbitItems);

            mockItemsRepository.Verify(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>()), Times.Once());
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryAddCorrectParameter_IfRangeCorrect()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            sut.ProvideRangeToWorkWith(SystemOneOrbitItems);

            mockItemsRepository.Verify(m => m.Add(SystemOneOrbitItems));
        }

        [Fact]
        public void ReturnsFalse_IfRangeHasNoOrbitZero()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);

            var result = sut.ProvideRangeToWorkWith([SystemOneSataliteOne, SystemOneSataliteTwo]);

            Assert.False(result);
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryGetAll_IfRangeHasNoOrbitZero()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            sut.ProvideRangeToWorkWith(SystemOneOrbitItems);

            mockItemsRepository.Verify(m => m.GetAll(), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryDelete_IfIOrbitItemsRepositoryGetAllReturnsAnything_IfRangeHasNoOrbitZero()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemTwoOrbitItems);

            sut.ProvideRangeToWorkWith([SystemOneSataliteOne, SystemOneSataliteTwo]);

            mockItemsRepository.Verify(m => m.Delete(It.IsAny<Entities.OrbitItem>()), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryAdd_IfRangeHasNoOrbitZero()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);

            sut.ProvideRangeToWorkWith([SystemOneSataliteOne, SystemOneSataliteTwo]); ;

            mockItemsRepository.Verify(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>()), Times.Never());
        }

        [Fact]
        public void ReturnsFalse_IfRangeHasMultipleOrbitZero()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);

            var result = sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, SystemTwoStar]);

            Assert.False(result);
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryGetAll_IfRangeHasMultipleOrbitZero()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, SystemTwoStar]);

            mockItemsRepository.Verify(m => m.GetAll(), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryDelete_IfIOrbitItemsRepositoryGetAllReturnsAnything_IfRangeHasMultipleOrbitZero()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemTwoOrbitItems);

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, SystemTwoStar]);

            mockItemsRepository.Verify(m => m.Delete(It.IsAny<Entities.OrbitItem>()), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryAdd_IfRangeHasMultipleOrbitZero()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, SystemTwoStar]);

            mockItemsRepository.Verify(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>()), Times.Never());
        }

        [Fact]
        public void ReturnsFalse_IfRangeHasInfiniteOrbitLoop()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            SystemOneSataliteOne.OrbitingId = SystemOneSataliteTwo.Id;
            SystemOneSataliteTwo.OrbitingId = SystemOneSataliteOne.Id;

            var result = sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo]);

            Assert.False(result);
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryGetAll_IfRangeHasInfiniteOrbitLoop()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            SystemOneSataliteOne.OrbitingId = SystemOneSataliteTwo.Id;
            SystemOneSataliteTwo.OrbitingId = SystemOneSataliteOne.Id;

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo]);

            mockItemsRepository.Verify(m => m.GetAll(), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryDelete_IfIOrbitItemsRepositoryGetAllReturnsAnything_IfRangeHasInfiniteOrbitLoop()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemTwoOrbitItems);
            SystemOneSataliteOne.OrbitingId = SystemOneSataliteTwo.Id;
            SystemOneSataliteTwo.OrbitingId = SystemOneSataliteOne.Id;

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo]);

            mockItemsRepository.Verify(m => m.Delete(It.IsAny<Entities.OrbitItem>()), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryAdd_IfRangeHasInfiniteOrbitLoop()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            SystemOneSataliteOne.OrbitingId = SystemOneSataliteTwo.Id;
            SystemOneSataliteTwo.OrbitingId = SystemOneSataliteOne.Id;

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo]);

            mockItemsRepository.Verify(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>()), Times.Never());
        }

        [Fact]
        public void ReturnsFalse_IfRangeHasItemOrbitingNonexistingItem()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);

            var result = sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, SystemTwoSubSataliteTwo]);

            Assert.False(result);
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryGetAll_IfRangeHasItemOrbitingNonexistingItem()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, SystemTwoSubSataliteTwo]);

            mockItemsRepository.Verify(m => m.GetAll(), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryDelete_IfIOrbitItemsRepositoryGetAllReturnsAnything_IfRangeHasItemOrbitingNonexistingItem()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemTwoOrbitItems);

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, SystemTwoSubSataliteTwo]);

            mockItemsRepository.Verify(m => m.Delete(It.IsAny<Entities.OrbitItem>()), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryAdd_IfRangeHasItemOrbitingNonexistingItem()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, SystemTwoSubSataliteTwo]);

            mockItemsRepository.Verify(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>()), Times.Never());
        }

        [Fact]
        public void ReturnsFalse_IfRangeHasItemWithSameId()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            SystemOneSataliteTwo.Id = SystemOneSataliteOne.Id;

            var result = sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo]);

            Assert.False(result);
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryGetAll_IfRangeHasItemWithSameId()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            SystemOneSataliteTwo.Id = SystemOneSataliteOne.Id;

            var result = sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo]);

            mockItemsRepository.Verify(m => m.GetAll(), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryDelete_IfIOrbitItemsRepositoryGetAllReturnsAnything_IfRangeHasItemWithSameId()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemTwoOrbitItems);
            SystemOneSataliteTwo.Id = SystemOneSataliteOne.Id;

            var result = sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo]);

            mockItemsRepository.Verify(m => m.Delete(It.IsAny<Entities.OrbitItem>()), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryAdd_IfRangeHasItemWithSameId()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            SystemOneSataliteTwo.Id = SystemOneSataliteOne.Id;

            var result = sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo]);

            mockItemsRepository.Verify(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>()), Times.Never());
        }

        [Fact]
        public void ReturnsFalse_IfRangeHasItemWithSameValuesExceptIdAndOrbitingId()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            Entities.OrbitItem copy = Copy(SystemOneSataliteTwo);
            copy.Id += 10;
            copy.OrbitingId = SystemOneSataliteTwo.Id;

            var result = sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, copy]);

            Assert.False(result);
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryGetAll_IfRangeHasItemWithSameValuesExceptIdAndOrbitingId()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            Entities.OrbitItem copy = Copy(SystemOneSataliteTwo);
            copy.Id += 10;
            copy.OrbitingId = SystemOneSataliteTwo.Id;

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, copy]);

            mockItemsRepository.Verify(m => m.GetAll(), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryDelete_IfIOrbitItemsRepositoryGetAllReturnsAnything_IfRangeHasItemWithSameValuesExceptIdAndOrbitingId()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
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
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            Entities.OrbitItem copy = Copy(SystemOneSataliteTwo);
            copy.Id += 10;
            copy.OrbitingId = SystemOneSataliteTwo.Id;

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, copy]);

            mockItemsRepository.Verify(m => m.Add(It.IsAny<IEnumerable<Entities.OrbitItem>>()), Times.Never());
        }

        [Fact]
        public void ReturnsFalse_IfRangeHasItemWithSameValuesExceptId()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            Entities.OrbitItem copy = Copy(SystemOneSataliteTwo);
            copy.Id += 10;

            var result = sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, copy]);

            Assert.False(result);
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryGetAll_IfRangeHasItemWithSameValuesExceptId()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            Entities.OrbitItem copy = Copy(SystemOneSataliteTwo);
            copy.Id += 10;

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, copy]);

            mockItemsRepository.Verify(m => m.GetAll(), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryDelete_IfIOrbitItemsRepositoryGetAllReturnsAnything_IfRangeHasItemWithSameValuesExceptId()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemTwoOrbitItems);
            Entities.OrbitItem copy = Copy(SystemOneSataliteTwo);
            copy.Id += 10;

            sut.ProvideRangeToWorkWith([SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, copy]);

            mockItemsRepository.Verify(m => m.Delete(It.IsAny<Entities.OrbitItem>()), Times.Never());
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryAdd_IfRangeHasItemWithSameValuesExceptId()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
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

            Assert.ThrowsAny<Exception>(() => sut.ProvideRangeToWorkWith(SystemOneOrbitItems));
        }

        [Fact]
        public void NotInvokesIOrbitItemsRepositoryAdd_IfIOrbitItemsRepositoryGetAllReturnsAnything_IfIOrbitItemsRepositoryDeleteReturnsFalse()
        {
            mockItemsRepository.Setup(m => m.Add(SystemOneOrbitItems)).Returns(true);
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
