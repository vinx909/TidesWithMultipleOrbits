using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.TideCalculator
{
    public class TimeTillRestart : TideCalculatorTestBase
    {
        [Fact]
        public void CallsIOrbitItemRepositoryGetAll()
        {
            sut.TimeTillRestart();

            mockItemsRepository.Verify(m => m.GetAll());
        }

        [Fact]
        public void ReturnsNegativeOne_IfIOrbitItemRepositoryGetAllReturnsNull()
        {
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: null);

            var result = sut.TimeTillRestart();

            Assert.Equal(-1, result);
        }

        [Fact]
        public void ReturnsNegativeOne_IfIOrbitItemRepositoryGetAllReturnsEmpty()
        {
            mockItemsRepository.Setup(m => m.GetAll()).Returns([]);

            var result = sut.TimeTillRestart();

            Assert.Equal(-1, result);
        }

        [Fact]
        public void ReturnsCorrectZero_IfAlwaysSame_DueToSingleOrbitingItem()
        {
            mockItemsRepository.Setup(m => m.GetAll()).Returns([SystemOneStar, SystemOneSataliteOne]);

            var result = sut.TimeTillRestart();

            Assert.Equal(0, result);
        }

        [Fact]
        public void ReturnsCorrectZero_IfAlwaysSame_DueToAllOrbitItemsHavingSameOrbitPeriod()
        {
            SystemOneSataliteTwo.OrbitPeriod=SystemOneSataliteOne.OrbitPeriod;
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemOneOrbitItems);

            var result = sut.TimeTillRestart();

            Assert.Equal(0, result);
        }

        [Fact]
        public void ReturnsCorrect_TwoOrbitingItems()
        {
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemOneOrbitItems);

            var result = sut.TimeTillRestart();

            Assert.Equal(4, result);
        }

        [Fact]
        public void ReturnsCorrect_TwoOrbitingItems_ThatReturnToSameHalfwayOfOneOrbitingPeriod()
        {
            SystemOneSataliteOne.OrbitPeriod = 2;
            SystemOneSataliteTwo.OrbitPeriod = 6;
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemOneOrbitItems);

            var result = sut.TimeTillRestart();

            Assert.Equal(3, result);
        }

        [Fact]
        public void ReturnsCorrect_TwoOrbitingItems_ThatDoNotReturnToSameAtEndOfOneOrbitngPeriod()
        {
            SystemOneSataliteOne.OrbitPeriod = 17;
            SystemOneSataliteTwo.OrbitPeriod = 15;
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemOneOrbitItems);

            var result = sut.TimeTillRestart();

            Assert.Equal(255, result);
        }

        [Fact]
        public void ReturnsCorrect_ManyOrbitingItems()
        {
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemTwoOrbitItems);

            var result = sut.TimeTillRestart();

            Assert.Equal(4, result);
        }
    }
}
