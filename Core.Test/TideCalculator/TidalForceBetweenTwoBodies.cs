using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.TideCalculator
{
    public class TidalForceBetweenTwoBodies : TideCalculatorTestBase
    {
        [Fact]
        public void CallsGetIdOfOrbitItem()
        {
            sut.TidalForceBetweenTwoBodies(SystemTwoStar, SystemTwoSataliteOne, 0);

            mockItemsRepository.Verify(m => m.GetIdOf(It.IsAny<Entities.OrbitItem>()));
        }

        [Fact]
        public void CallsGetIdOfOrbitItemWithGivenItems()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem satalite = SystemTwoSataliteOne;
            sut.TidalForceBetweenTwoBodies(satalite, star, 0);

            mockItemsRepository.Verify(m => m.GetIdOf(star));
            mockItemsRepository.Verify(m => m.GetIdOf(satalite));
        }

        [Fact]
        public void ReturnsNegativeOne_WhenItemNotInRange()
        {
            mockItemsRepository.Setup(m => m.GetIdOf(It.IsAny<Entities.OrbitItem>())).Returns(value: null);

            var result = sut.TidalForceBetweenTwoBodies(SystemTwoStar, SystemTwoSataliteOne, 0);

            Assert.Equal(-1, result);
        }

        [Fact]
        public void ReturnsNegativeOne_WhenItemWithSameId()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem satalite = SystemTwoSataliteOne;
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(satalite)).Returns(star.Id);

            var result = sut.TidalForceBetweenTwoBodies(satalite, star, 0);

            Assert.Equal(-1, result);
        }

        [Fact]
        public void CallsGetInt()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem satalite = SystemTwoSataliteOne;
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(satalite)).Returns(satalite.Id);

            sut.TidalForceBetweenTwoBodies(star, satalite, 0);

            mockItemsRepository.Verify(m => m.Get(It.IsAny<int>()));
        }

        [Fact]
        public void CallsGetExpectedAmountsOfTimes()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem satalite = SystemTwoSataliteOne;
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(satalite)).Returns(satalite.Id);

            sut.TidalForceBetweenTwoBodies(star, satalite, 0);

            mockItemsRepository.Verify(m => m.Get(It.IsAny<int>()), Times.Exactly(2));
        }

        [Fact]
        public void CallsGetWithReturnedIds()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem satalite = SystemTwoSataliteOne;
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(satalite)).Returns(satalite.Id);

            sut.TidalForceBetweenTwoBodies(star, satalite, 0);

            mockItemsRepository.Verify(m => m.Get(star.Id));
            mockItemsRepository.Verify(m => m.Get(satalite.Id));
        }

        [Fact]
        public void ReturnsCorrect_StarOnSatalite()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem satalite = SystemTwoSataliteOne;
            double distance = satalite.OrbitingDistance;
            double expected = GetTidalForce(star.Mass, satalite.Radius, distance);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(satalite)).Returns(satalite.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(satalite.Id)).Returns(satalite);

            var result = sut.TidalForceBetweenTwoBodies(satalite, star, 0);

            Assert.Equal(expected, result, tolerance);
        }

        [Fact]
        public void ReturnsCorrect_SataliteOnSataliteStartPosition()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem sataliteOne = SystemTwoSataliteOne;
            Entities.OrbitItem sataliteTwo = SystemTwoSataliteTwo;
            double distance = sataliteTwo.OrbitingDistance - sataliteOne.OrbitingDistance;
            double expected = GetTidalForce(sataliteTwo.Mass, sataliteOne.Radius, distance);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);

            var result = sut.TidalForceBetweenTwoBodies(sataliteOne, sataliteTwo, 0);

            Assert.Equal(expected, result, tolerance);
        }

        [Fact]
        public void ReturnsCorrect_SataliteOnSatalite180Degrees()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem sataliteOne = SystemTwoSataliteOne;
            Entities.OrbitItem sataliteTwo = SystemTwoSataliteTwo;
            double distance = sataliteTwo.OrbitingDistance + sataliteOne.OrbitingDistance;
            double expected = GetTidalForce(sataliteTwo.Mass, sataliteOne.Radius, distance);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);

            var result = sut.TidalForceBetweenTwoBodies(sataliteOne, sataliteTwo, 2);

            Assert.Equal(expected, result, tolerance);
        }

        [Fact]
        public void ReturnsCorrect_SataliteOnSatalite90Degrees()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem sataliteOne = SystemTwoSataliteOne;
            Entities.OrbitItem sataliteTwo = SystemTwoSataliteTwo;
            double distance = Math.Pow(Math.Pow(sataliteTwo.OrbitingDistance, 2) + Math.Pow(sataliteOne.OrbitingDistance, 2), 0.5);
            double expected = GetTidalForce(sataliteTwo.Mass, sataliteOne.Radius, distance);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);

            var result = sut.TidalForceBetweenTwoBodies(sataliteOne, sataliteTwo, 1);

            Assert.Equal(expected, result, tolerance);
        }

        [Fact]
        public void CallGetIntExpectedAmountsOfTimes_SataliteOnSubSubSataliteComplicated()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem sataliteOne = SystemTwoSataliteOne;
            Entities.OrbitItem sataliteTwo = SystemTwoSataliteTwo;
            Entities.OrbitItem subSatalites = SystemTwoSubSataliteOne;
            Entities.OrbitItem subSubSatalites = SystemTwoSubSubSatalite;
            double distance = sataliteTwo.OrbitingDistance - subSubSatalites.OrbitingDistance;
            double expected = GetTidalForce(sataliteOne.Mass, subSubSatalites.Radius, distance);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(subSatalites)).Returns(subSatalites.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(subSubSatalites)).Returns(subSubSatalites.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);
            mockItemsRepository.Setup(m => m.Get(subSatalites.Id)).Returns(subSatalites);
            mockItemsRepository.Setup(m => m.Get(subSubSatalites.Id)).Returns(subSubSatalites);

            sut.TidalForceBetweenTwoBodies(subSubSatalites, sataliteOne, 1);

            mockItemsRepository.Verify(m => m.Get(It.IsAny<int>()), Times.Exactly(5));
        }

        [Fact]
        public void CallGetWithOrbitingIds_SataliteOnSubSubSataliteComplicated()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem sataliteOne = SystemTwoSataliteOne;
            Entities.OrbitItem sataliteTwo = SystemTwoSataliteTwo;
            Entities.OrbitItem subSatalites = SystemTwoSubSataliteOne;
            Entities.OrbitItem subSubSatalites = SystemTwoSubSubSatalite;
            double distance = sataliteTwo.OrbitingDistance - subSubSatalites.OrbitingDistance;
            double expected = GetTidalForce(sataliteOne.Mass, subSubSatalites.Radius, distance);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(subSatalites)).Returns(subSatalites.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(subSubSatalites)).Returns(subSubSatalites.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);
            mockItemsRepository.Setup(m => m.Get(subSatalites.Id)).Returns(subSatalites);
            mockItemsRepository.Setup(m => m.Get(subSubSatalites.Id)).Returns(subSubSatalites);

            sut.TidalForceBetweenTwoBodies(subSubSatalites, sataliteOne, 1);

            mockItemsRepository.Verify(m => m.Get(star.Id));
            mockItemsRepository.Verify(m => m.Get(sataliteOne.Id));
            mockItemsRepository.Verify(m => m.Get(sataliteTwo.Id));
            mockItemsRepository.Verify(m => m.Get(subSatalites.Id));
            mockItemsRepository.Verify(m => m.Get(subSubSatalites.Id));
        }

        [Fact]
        public void ReturnsCorrect_SataliteOnSubSubSataliteComplicated()
        {
            Entities.OrbitItem star = SystemTwoStar;
            Entities.OrbitItem sataliteOne = SystemTwoSataliteOne;
            Entities.OrbitItem sataliteTwo = SystemTwoSataliteTwo;
            Entities.OrbitItem subSatalites = SystemTwoSubSataliteOne;
            Entities.OrbitItem subSubSatalites = SystemTwoSubSubSatalite;
            double distance = sataliteTwo.OrbitingDistance - subSubSatalites.OrbitingDistance;
            double expected = GetTidalForce(sataliteOne.Mass, subSubSatalites.Radius, distance);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(subSatalites)).Returns(subSatalites.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(subSubSatalites)).Returns(subSubSatalites.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);
            mockItemsRepository.Setup(m => m.Get(subSatalites.Id)).Returns(subSatalites);
            mockItemsRepository.Setup(m => m.Get(subSubSatalites.Id)).Returns(subSubSatalites);

            var result = sut.TidalForceBetweenTwoBodies(subSubSatalites, sataliteOne, 1);

            Assert.Equal(expected, result, tolerance);
        }
    }
}
