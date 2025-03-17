using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Services.TideCalculator;

namespace Core.Test.TideCalculator
{
    public class AngleTo : TideCalculatorTestBase
    {
        [Fact]
        public void CallsGetIdOfOrbitItem()
        {
            sut.AngleTo(SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, 1);

            mockItemsRepository.Verify(m => m.GetIdOf(It.IsAny<Entities.OrbitItem>()));
        }

        [Fact]
        public void CallsGetIdOfOrbitItemWithGivenItems()
        {
            sut.AngleTo(SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, 1);

            mockItemsRepository.Verify(m => m.GetIdOf(SystemOneStar));
            mockItemsRepository.Verify(m => m.GetIdOf(SystemOneSataliteOne));
            mockItemsRepository.Verify(m => m.GetIdOf(SystemOneSataliteTwo));
        }

        [Fact]
        public void ThrowsException_WhenItemNotInRange()
        {
            mockItemsRepository.Setup(m => m.GetIdOf(It.IsAny<Entities.OrbitItem>())).Returns(value: null);

            Assert.ThrowsAny<Exception>(() => sut.AngleTo(SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, 1));
        }

        [Fact]
        public void ThrowsNotInGivenRangeException_WhenItemNotInRange()
        {
            mockItemsRepository.Setup(m => m.GetIdOf(It.IsAny<Entities.OrbitItem>())).Returns(value: null);

            Assert.Throws<NotInGivenRangeException>(() => sut.AngleTo(SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, 1));
        }

        [Fact]
        public void CallsGetInt()
        {
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneStar)).Returns(SystemOneStar.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteOne)).Returns(SystemOneSataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteTwo)).Returns(SystemOneSataliteTwo.Id);

            sut.AngleTo(SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, 1);

            mockItemsRepository.Verify(m => m.Get(It.IsAny<int>()));
        }

        [Fact]
        public void CallsGetWithReturnedIds()
        {
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneStar)).Returns(SystemOneStar.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteOne)).Returns(SystemOneSataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteTwo)).Returns(SystemOneSataliteTwo.Id);

            sut.AngleTo(SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, 1);

            mockItemsRepository.Verify(m => m.Get(SystemOneStar.Id));
            mockItemsRepository.Verify(m => m.Get(SystemOneSataliteOne.Id));
            mockItemsRepository.Verify(m => m.Get(SystemOneSataliteTwo.Id));
        }
    }
}
