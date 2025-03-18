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
        const double tolerance = 0.00000000001;

        [Fact]
        public void ReturnsFour_ItemsWithSameId()
        {
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneStar)).Returns(SystemOneStar.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteOne)).Returns(SystemOneSataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteTwo)).Returns(SystemOneSataliteOne.Id);

            var result = sut.AngleTo(SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, 1);

            Assert.Equal(4, result);
        }

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
        public void ReturnsFour_WhenItemNotInRange()
        {
            mockItemsRepository.Setup(m => m.GetIdOf(It.IsAny<Entities.OrbitItem>())).Returns(value: null);

            var result = sut.AngleTo(SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, 1);

            Assert.Equal(4, result);
        }

        [Fact]
        public void CallsGetInt_Angle90Degrees()
        {
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneStar)).Returns(SystemOneStar.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteOne)).Returns(SystemOneSataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteTwo)).Returns(SystemOneSataliteTwo.Id);

            sut.AngleTo(SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, 1);

            mockItemsRepository.Verify(m => m.Get(It.IsAny<int>()));
        }

        [Fact]
        public void CallsGetIntExpectedAmountsOfTimes_Angle90Degrees()
        {
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneStar)).Returns(SystemOneStar.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteOne)).Returns(SystemOneSataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteTwo)).Returns(SystemOneSataliteTwo.Id);

            sut.AngleTo(SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, 1);

            mockItemsRepository.Verify(m => m.Get(It.IsAny<int>()), Times.Exactly(3));
        }

        [Fact]
        public void CallsGetWithReturnedIds_Angle90Degrees()
        {
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneStar)).Returns(SystemOneStar.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteOne)).Returns(SystemOneSataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteTwo)).Returns(SystemOneSataliteTwo.Id);

            sut.AngleTo(SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, 1);

            mockItemsRepository.Verify(m => m.Get(SystemOneStar.Id));
            mockItemsRepository.Verify(m => m.Get(SystemOneSataliteOne.Id));
            mockItemsRepository.Verify(m => m.Get(SystemOneSataliteTwo.Id));
        }

        [Fact]
        public void ReturnsCorrect_Angle90Degrees()
        {
            double expected = Math.Acos(0);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneStar)).Returns(SystemOneStar.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteOne)).Returns(SystemOneSataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteTwo)).Returns(SystemOneSataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(SystemOneStar.Id)).Returns(SystemOneStar);
            mockItemsRepository.Setup(m => m.Get(SystemOneSataliteOne.Id)).Returns(SystemOneSataliteOne);
            mockItemsRepository.Setup(m => m.Get(SystemOneSataliteTwo.Id)).Returns(SystemOneSataliteTwo);

            var result = sut.AngleTo(SystemOneStar, SystemOneSataliteTwo, SystemOneSataliteOne, 1);

            Assert.Equal(expected, result, tolerance);
        }

        [Fact]
        public void ReturnsCorrect_AngleNegative90Degrees()
        {
            double expected = -Math.Acos(0);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneStar)).Returns(SystemOneStar.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteOne)).Returns(SystemOneSataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteTwo)).Returns(SystemOneSataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(SystemOneStar.Id)).Returns(SystemOneStar);
            mockItemsRepository.Setup(m => m.Get(SystemOneSataliteOne.Id)).Returns(SystemOneSataliteOne);
            mockItemsRepository.Setup(m => m.Get(SystemOneSataliteTwo.Id)).Returns(SystemOneSataliteTwo);

            var result = sut.AngleTo(SystemOneStar, SystemOneSataliteOne, SystemOneSataliteTwo, 1);

            Assert.Equal(expected, result, tolerance);
        }

        [Fact]
        public void CallsGetInt_Angle45Degrees()
        {
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneStar)).Returns(SystemOneStar.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteOne)).Returns(SystemOneSataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteTwo)).Returns(SystemOneSataliteTwo.Id);

            var result = sut.AngleTo(SystemOneSataliteOne, SystemOneStar, SystemOneSataliteTwo, 1);

            mockItemsRepository.Verify(m => m.Get(It.IsAny<int>()));
        }


        [Fact]
        public void CallsGetIntExpectedAmountsOfTimes_Angle45Degrees()
        {
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneStar)).Returns(SystemOneStar.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteOne)).Returns(SystemOneSataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteTwo)).Returns(SystemOneSataliteTwo.Id);

            var result = sut.AngleTo(SystemOneSataliteOne, SystemOneStar, SystemOneSataliteTwo, 1);

            mockItemsRepository.Verify(m => m.Get(It.IsAny<int>()), Times.Exactly(3));
        }

        [Fact]
        public void CallsGetWithReturnedIds_Angle45Degrees()
        {
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneStar)).Returns(SystemOneStar.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteOne)).Returns(SystemOneSataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteTwo)).Returns(SystemOneSataliteTwo.Id);

            var result = sut.AngleTo(SystemOneSataliteOne, SystemOneStar, SystemOneSataliteTwo, 1);

            mockItemsRepository.Verify(m => m.Get(SystemOneStar.Id));
            mockItemsRepository.Verify(m => m.Get(SystemOneSataliteOne.Id));
            mockItemsRepository.Verify(m => m.Get(SystemOneSataliteTwo.Id));
        }

        [Fact]
        public void ReturnsCorrect_Angle45Degrees()
        {
            double expected = Math.Acos(1 / Math.Pow(2, 0.5));
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneStar)).Returns(SystemOneStar.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteOne)).Returns(SystemOneSataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteTwo)).Returns(SystemOneSataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(SystemOneStar.Id)).Returns(SystemOneStar);
            mockItemsRepository.Setup(m => m.Get(SystemOneSataliteOne.Id)).Returns(SystemOneSataliteOne);
            mockItemsRepository.Setup(m => m.Get(SystemOneSataliteTwo.Id)).Returns(SystemOneSataliteTwo);

            var result = sut.AngleTo(SystemOneSataliteOne, SystemOneStar, SystemOneSataliteTwo, 1);

            Assert.Equal(expected, result, tolerance);
        }

        [Fact]
        public void ReturnsCorrect_AngleNegative45Degrees()
        {
            double expected = -Math.Acos(1 / Math.Pow(2, 0.5));
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneStar)).Returns(SystemOneStar.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteOne)).Returns(SystemOneSataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteTwo)).Returns(SystemOneSataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(SystemOneStar.Id)).Returns(SystemOneStar);
            mockItemsRepository.Setup(m => m.Get(SystemOneSataliteOne.Id)).Returns(SystemOneSataliteOne);
            mockItemsRepository.Setup(m => m.Get(SystemOneSataliteTwo.Id)).Returns(SystemOneSataliteTwo);

            var result = sut.AngleTo(SystemOneSataliteOne, SystemOneSataliteTwo, SystemOneStar, 1);

            Assert.Equal(expected, result, tolerance);
        }

        [Fact]
        public void ReturnsCorrect_Angle180Degrees()
        {
            double expected = Math.Acos(-1);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneStar)).Returns(SystemOneStar.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteOne)).Returns(SystemOneSataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteTwo)).Returns(SystemOneSataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(SystemOneStar.Id)).Returns(SystemOneStar);
            mockItemsRepository.Setup(m => m.Get(SystemOneSataliteOne.Id)).Returns(SystemOneSataliteOne);
            mockItemsRepository.Setup(m => m.Get(SystemOneSataliteTwo.Id)).Returns(SystemOneSataliteTwo);
            
            var result = sut.AngleTo(SystemOneStar, SystemOneSataliteTwo, SystemOneSataliteOne, 2);

            Assert.Equal(expected, result, tolerance);
        }

        [Fact]
        public void ReturnsCorrect_Angle180Degrees_NotNegative()
        {
            double expected = Math.Acos(-1);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneStar)).Returns(SystemOneStar.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteOne)).Returns(SystemOneSataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(SystemOneSataliteTwo)).Returns(SystemOneSataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(SystemOneStar.Id)).Returns(SystemOneStar);
            mockItemsRepository.Setup(m => m.Get(SystemOneSataliteOne.Id)).Returns(SystemOneSataliteOne);
            mockItemsRepository.Setup(m => m.Get(SystemOneSataliteTwo.Id)).Returns(SystemOneSataliteTwo);

            var result = sut.AngleTo(SystemOneStar, SystemOneSataliteTwo, SystemOneSataliteOne, 2);

            Assert.Equal(expected, result, tolerance);
        }
    }
}
