using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.TideCalculator
{
    public class DistanceAndAngleBetween : TideCalculatorTestBase
    {
        [Fact]
        public void CallsGetIdOfOrbitItem()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem sataliteOne = SystemTwoSataliteOne;
            Entities.OrbitItem sataliteTwo = SystemTwoSataliteTwo;

            sut.DistanceAndAngleBetween(sataliteTwo, sataliteOne, star, 0);

            mockItemsRepository.Verify(m => m.GetIdOf(It.IsAny<Entities.OrbitItem>()));
        }

        [Fact]
        public void CallsGetIdOfOrbitItemWithGivenItems()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem sataliteOne = SystemTwoSataliteOne;
            Entities.OrbitItem sataliteTwo = SystemTwoSataliteTwo;

            sut.DistanceAndAngleBetween(sataliteTwo, sataliteOne, star, 0);

            mockItemsRepository.Verify(m => m.GetIdOf(star));
            mockItemsRepository.Verify(m => m.GetIdOf(sataliteOne));
            mockItemsRepository.Verify(m => m.GetIdOf(sataliteTwo));
        }

        [Fact]
        public void ReturnsFourNegativeOne_WhenItemNotInRange()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem sataliteOne = SystemTwoSataliteOne;
            Entities.OrbitItem sataliteTwo = SystemTwoSataliteTwo;
            mockItemsRepository.Setup(m => m.GetIdOf(It.IsAny<Entities.OrbitItem>())).Returns(value: null);

            var result = sut.DistanceAndAngleBetween(sataliteTwo, sataliteOne, star, 0);

            Assert.Equal((4, -1), result);
        }

        [Fact]
        public void ReturnsFourNegativeOne_WhenItemWithSameId()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem sataliteOne = SystemTwoSataliteOne;
            Entities.OrbitItem sataliteTwo = SystemTwoSataliteTwo;
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteOne.Id);

            var result = sut.DistanceAndAngleBetween(sataliteTwo, sataliteOne, star, 0);

            Assert.Equal((4, -1), result);
        }

        [Fact]
        public void CallsGetInt()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem sataliteOne = SystemTwoSataliteOne;
            Entities.OrbitItem sataliteTwo = SystemTwoSataliteTwo;
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);

            sut.DistanceAndAngleBetween(sataliteTwo, sataliteOne, star, 0);

            mockItemsRepository.Verify(m => m.Get(It.IsAny<int>()));
        }

        [Fact]
        public void CallsGetExpectedAmountsOfTimes()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem sataliteOne = SystemTwoSataliteOne;
            Entities.OrbitItem sataliteTwo = SystemTwoSataliteTwo;
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);

            sut.DistanceAndAngleBetween(sataliteTwo, sataliteOne, star, 0);

            mockItemsRepository.Verify(m => m.Get(It.IsAny<int>()), Times.Exactly(3));
        }

        [Fact]
        public void CallsGetWithReturnedIds()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem sataliteOne = SystemTwoSataliteOne;
            Entities.OrbitItem sataliteTwo = SystemTwoSataliteTwo;
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);

            sut.DistanceAndAngleBetween(sataliteTwo, sataliteOne, star, 0);

            mockItemsRepository.Verify(m => m.Get(star.Id));
            mockItemsRepository.Verify(m => m.Get(sataliteOne.Id));
            mockItemsRepository.Verify(m => m.Get(sataliteTwo.Id));
        }

        [Fact]
        public void ReturnsCorrectAngle_ZeroDegrees()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem sataliteOne = SystemTwoSataliteOne;
            Entities.OrbitItem sataliteTwo = SystemTwoSataliteTwo;
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);

            var result = sut.DistanceAndAngleBetween(sataliteTwo, sataliteOne, star, 0);

            Assert.Equal(Math.Acos(1), result.Item1);
        }

        [Fact]
        public void ReturnsCorrectDistance_ZeroDegrees()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem sataliteOne = SystemTwoSataliteOne;
            Entities.OrbitItem sataliteTwo = SystemTwoSataliteTwo;
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);

            var result = sut.DistanceAndAngleBetween(sataliteTwo, sataliteOne, star, 0);

            Assert.Equal(sataliteTwo.OrbitingDistance - sataliteOne.OrbitingDistance, result.Item1);
        }

        [Fact]
        public void ReturnsCorrectAngle_180Degrees()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem sataliteOne = SystemTwoSataliteOne;
            Entities.OrbitItem sataliteTwo = SystemTwoSataliteTwo;
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);

            var result = sut.DistanceAndAngleBetween(sataliteTwo, sataliteOne, star, 2);

            Assert.Equal(Math.Acos(1), result.Item1);
        }

        [Fact]
        public void ReturnsCorrectDistance_180Degrees()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem sataliteOne = SystemTwoSataliteOne;
            Entities.OrbitItem sataliteTwo = SystemTwoSataliteTwo;
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);

            var result = sut.DistanceAndAngleBetween(sataliteTwo, sataliteOne, star, 2);

            Assert.Equal(sataliteTwo.OrbitingDistance + sataliteOne.OrbitingDistance, result.Item1);
        }

        [Fact]
        public void ReturnsCorrectAngle_90Degrees()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem sataliteOne = SystemTwoSataliteOne;
            Entities.OrbitItem sataliteTwo = SystemTwoSataliteTwo;
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);

            var result = sut.DistanceAndAngleBetween(sataliteTwo, sataliteOne, star, 1);

            Assert.Equal(Math.Acos(4/(2*Math.Pow(5,0.5))), result.Item1);
        }

        [Fact]
        public void ReturnsCorrectDistance_90Degrees()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem sataliteOne = SystemTwoSataliteOne;
            Entities.OrbitItem sataliteTwo = SystemTwoSataliteTwo;
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);

            var result = sut.DistanceAndAngleBetween(sataliteTwo, sataliteOne, star, 1);

            Assert.Equal(Math.Pow(Math.Pow(sataliteTwo.OrbitingDistance, 2) + Math.Pow(sataliteOne.OrbitingDistance, 2), 0.5), result.Item1);
        }

        [Fact]
        public void ReturnsCorrectAngle_negative90Degrees()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem sataliteOne = SystemTwoSataliteOne;
            Entities.OrbitItem sataliteTwo = SystemTwoSataliteTwo;
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);

            var result = sut.DistanceAndAngleBetween(sataliteTwo, sataliteOne, star, 3);

            Assert.Equal(Math.Acos(4 / (2 * Math.Pow(5, 0.5))), result.Item1);
        }

        [Fact]
        public void ReturnsCorrectDistance_negative90Degrees()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem sataliteOne = SystemTwoSataliteOne;
            Entities.OrbitItem sataliteTwo = SystemTwoSataliteTwo;
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);

            var result = sut.DistanceAndAngleBetween(sataliteTwo, sataliteOne, star, 3);

            Assert.Equal(Math.Pow(Math.Pow(sataliteTwo.OrbitingDistance, 2) + Math.Pow(sataliteOne.OrbitingDistance, 2), 0.5), result.Item1);
        }
    }
}
