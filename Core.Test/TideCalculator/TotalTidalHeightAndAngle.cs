using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.TideCalculator
{
    public class TotalTidalHeightAndAngle : TideCalculatorTestBase
    {
        new readonly double tolerance = 0.0001;

        [Fact]
        public void CallsIOrbitItemRepositoryGetAll()
        {
            sut.TotalTidalHeightAndAngle(SystemOneStar, SystemOneSataliteTwo, 0);

            mockItemsRepository.Verify(m => m.GetAll());
        }

        [Fact]
        public void ReturnsCorrectNumbersIndicatingIncorrect_IfIOrbitItemRepositoryGetAllReturnsNull()
        {
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: null);

            var result = sut.TotalTidalHeightAndAngle(SystemOneStar, SystemOneSataliteTwo, 0);

            Assert.Equal(-1, result.Item1);
            Assert.Equal(-1, result.Item2);
            Assert.Equal(-1, result.Item3);
            Assert.Equal(4, result.Item4);
        }

        [Fact]
        public void ReturnsCorrectNumbersIndicatingIncorrect_IfIOrbitItemRepositoryGetAllReturnsEmpty()
        {
            mockItemsRepository.Setup(m => m.GetAll()).Returns([]);

            var result = sut.TotalTidalHeightAndAngle(SystemOneStar, SystemOneSataliteTwo, 0);

            Assert.Equal(-1, result.Item1);
            Assert.Equal(-1, result.Item2);
            Assert.Equal(-1, result.Item3);
            Assert.Equal(4, result.Item4);
        }

        [Fact]
        public void ReturnsCorrectNumbersIndicatingIncorrect_IfExperiancingItemSameAsItemAtZeroDegrees()
        {
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemOneOrbitItems);

            var result = sut.TotalTidalHeightAndAngle(SystemOneStar, SystemOneStar, 0);

            Assert.Equal(-1, result.Item1);
            Assert.Equal(-1, result.Item2);
            Assert.Equal(-1, result.Item3);
            Assert.Equal(4, result.Item4);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(0, 2)]
        [InlineData(0, 3)]
        [InlineData(1, 2)]
        [InlineData(1, 3)]
        [InlineData(2, 3)]
        public void ReturnsThreeSame_AtDifferentTimes_WithBodiesAtSameDistance(int timeOne, int timeTwo)
        {
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemOneOrbitItems);

            var resultOne = sut.TotalTidalHeightAndAngle(SystemOneStar, SystemOneSataliteTwo, timeOne);
            var resultTwo = sut.TotalTidalHeightAndAngle(SystemOneStar, SystemOneSataliteTwo, timeTwo);

            Assert.Equal(resultOne.Item3, resultTwo.Item3, tolerance);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public void ReturnsOneAndTwoSame_WhenNeepTideWithEqualForces(int time)
        {
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemOneOrbitItems);

            var result = sut.TotalTidalHeightAndAngle(SystemOneStar, SystemOneSataliteTwo, time);

            Assert.Equal(result.Item1, result.Item2, tolerance);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public void ReturnsFourZero_WhenNeepTideWithEqualForces(int time)
        {
            mockItemsRepository.Setup(m => m.GetAll()).Returns(SystemOneOrbitItems);

            var result = sut.TotalTidalHeightAndAngle(SystemOneStar, SystemOneSataliteTwo, time);

            Assert.Equal(0, result.Item4, tolerance);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 2)]
        [InlineData(0, 2)]
        [InlineData(0, 3)]
        [InlineData(3, 2)]
        public void ReturnsThreeLessLow_WhenFurtherAway(int timeCloser, int timeFurther)
        {
            mockItemsRepository.Setup(m => m.GetAll()).Returns([SystemTwoStar, SystemTwoSataliteOne, SystemTwoSataliteTwo]);

            var resultCloser = sut.TotalTidalHeightAndAngle(SystemTwoSataliteTwo, SystemTwoStar, timeCloser);
            var resultFurther = sut.TotalTidalHeightAndAngle(SystemTwoSataliteTwo, SystemTwoStar, timeFurther);

            Assert.True(resultCloser.Item3 < resultFurther.Item3);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        public void ReturnsFourZero_WhenInLine(int time)
        {
            mockItemsRepository.Setup(m => m.GetAll()).Returns([SystemTwoStar, SystemTwoSataliteOne, SystemTwoSataliteTwo]);

            var result = sut.TotalTidalHeightAndAngle(SystemTwoStar, SystemTwoSataliteTwo, time);

            Assert.Equal(0, result.Item4, tolerance);
        }

        [Fact]
        public void ReturnsFourMoreThenZero_NotInLine()
        {
            mockItemsRepository.Setup(m => m.GetAll()).Returns([SystemTwoStar, SystemTwoSataliteOne, SystemTwoSataliteTwo]);

            var result = sut.TotalTidalHeightAndAngle(SystemTwoStar, SystemTwoSataliteTwo, 1);

            Assert.True(result.Item4 > 0);
        }

        [Fact]
        public void ReturnsFourLessThenZero_NotInLine()
        {
            mockItemsRepository.Setup(m => m.GetAll()).Returns([SystemTwoStar, SystemTwoSataliteOne, SystemTwoSataliteTwo]);

            var result = sut.TotalTidalHeightAndAngle(SystemTwoStar, SystemTwoSataliteTwo, 3);

            Assert.True(result.Item4 < 0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public void ReturnsTwoMoreThenThree_WhenNotInLine(int time)
        {
            mockItemsRepository.Setup(m => m.GetAll()).Returns([SystemTwoStar, SystemTwoSataliteOne, SystemTwoSataliteTwo]);

            var result = sut.TotalTidalHeightAndAngle(SystemTwoStar, SystemTwoSataliteTwo, 1);

            Assert.True(result.Item2 > result.Item3);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public void ReturnsTwoLessThenOne_WhenNotInLine(int time)
        {
            mockItemsRepository.Setup(m => m.GetAll()).Returns([SystemTwoStar, SystemTwoSataliteOne, SystemTwoSataliteTwo]);

            var result = sut.TotalTidalHeightAndAngle(SystemTwoStar, SystemTwoSataliteTwo, 1);

            Assert.True(result.Item2 < result.Item1);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        public void ReturnCorrectValueOne_InLine(int time)
        {
            double expected = -1;
            if (time == 0)
            {
                double distanceOne = SystemTwoSataliteTwo.OrbitingDistance;
                double heightOne = GetTidalHeight(SystemTwoStar.Mass, SystemTwoSataliteTwo.Mass, SystemTwoSataliteTwo.Radius, distanceOne);
                double distanceTwo = SystemTwoSataliteTwo.OrbitingDistance - SystemTwoSataliteOne.OrbitingDistance;
                double heightTwo = GetTidalHeight(SystemTwoSataliteOne.Mass, SystemTwoSataliteTwo.Mass, SystemTwoSataliteTwo.Radius, distanceTwo);
                expected = (heightOne + heightTwo) * 3 / 5;
            }
            else if (time == 2)
            {
                double distanceOne = SystemTwoSataliteTwo.OrbitingDistance;
                double heightOne = GetTidalHeight(SystemTwoStar.Mass, SystemTwoSataliteTwo.Mass, SystemTwoSataliteTwo.Radius, distanceOne);
                double distanceTwo = SystemTwoSataliteTwo.OrbitingDistance + SystemTwoSataliteOne.OrbitingDistance;
                double heightTwo = GetTidalHeight(SystemTwoSataliteOne.Mass, SystemTwoSataliteTwo.Mass, SystemTwoSataliteTwo.Radius, distanceTwo);
                expected = (heightOne + heightTwo) * 3 / 5;
            }
            if (expected == -1)
            {
                throw new Exception("test error: expected has not been set as the given time has no value setting it");
            }
            mockItemsRepository.Setup(m => m.GetAll()).Returns([SystemTwoStar, SystemTwoSataliteOne, SystemTwoSataliteTwo]);

            var result = sut.TotalTidalHeightAndAngle(SystemTwoSataliteTwo, SystemTwoStar, time);

            Assert.Equal(expected, result.Item1, tolerance);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        public void ReturnCorrectValueTwo_InLine(int time)
        {
            double expected = 1;
            if (time == 0)
            {
                double distanceOne = SystemTwoSataliteTwo.OrbitingDistance;
                double heightOne = GetTidalHeight(SystemTwoStar.Mass, SystemTwoSataliteTwo.Mass, SystemTwoSataliteTwo.Radius, distanceOne);
                double distanceTwo = SystemTwoSataliteTwo.OrbitingDistance - SystemTwoSataliteOne.OrbitingDistance;
                double heightTwo = GetTidalHeight(SystemTwoSataliteOne.Mass, SystemTwoSataliteTwo.Mass, SystemTwoSataliteTwo.Radius, distanceTwo);
                expected = (heightOne + heightTwo) * -0.4;
            }
            else if (time == 2)
            {
                double distanceOne = SystemTwoSataliteTwo.OrbitingDistance;
                double heightOne = GetTidalHeight(SystemTwoStar.Mass, SystemTwoSataliteTwo.Mass, SystemTwoSataliteTwo.Radius, distanceOne);
                double distanceTwo = SystemTwoSataliteTwo.OrbitingDistance + SystemTwoSataliteOne.OrbitingDistance;
                double heightTwo = GetTidalHeight(SystemTwoSataliteOne.Mass, SystemTwoSataliteTwo.Mass, SystemTwoSataliteTwo.Radius, distanceTwo);
                expected = (heightOne + heightTwo) * -0.4;
            }
            if (expected == 1)
            {
                throw new Exception("test error: expected has not been set as the given time has no value setting it");
            }
            mockItemsRepository.Setup(m => m.GetAll()).Returns([SystemTwoStar, SystemTwoSataliteOne, SystemTwoSataliteTwo]);

            var result = sut.TotalTidalHeightAndAngle(SystemTwoSataliteTwo, SystemTwoStar, time);

            Assert.Equal(expected, result.Item2, tolerance);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ReturnCorrectValueThree_InLine(int time)
        {
            double expected = 1;
            if (time == 0)
            {
                double distanceOne = SystemTwoSataliteTwo.OrbitingDistance;
                double heightOne = GetTidalHeight(SystemTwoStar.Mass, SystemTwoSataliteTwo.Mass, SystemTwoSataliteTwo.Radius, distanceOne);
                double distanceTwo = SystemTwoSataliteTwo.OrbitingDistance - SystemTwoSataliteOne.OrbitingDistance;
                double heightTwo = GetTidalHeight(SystemTwoSataliteOne.Mass, SystemTwoSataliteTwo.Mass, SystemTwoSataliteTwo.Radius, distanceTwo);
                expected = (heightOne + heightTwo) * -0.4;
            }
            else if (time == 2)
            {
                double distanceOne = SystemTwoSataliteTwo.OrbitingDistance;
                double heightOne = GetTidalHeight(SystemTwoStar.Mass, SystemTwoSataliteTwo.Mass, SystemTwoSataliteTwo.Radius, distanceOne);
                double distanceTwo = SystemTwoSataliteTwo.OrbitingDistance + SystemTwoSataliteOne.OrbitingDistance;
                double heightTwo = GetTidalHeight(SystemTwoSataliteOne.Mass, SystemTwoSataliteTwo.Mass, SystemTwoSataliteTwo.Radius, distanceTwo);
                expected = (heightOne + heightTwo) * -0.4;
            }
            else if (time == 1 || time == 3)
            {
                double distanceOne = SystemTwoSataliteTwo.OrbitingDistance;
                double heightOne = GetTidalHeight(SystemTwoStar.Mass, SystemTwoSataliteTwo.Mass, SystemTwoSataliteTwo.Radius, distanceOne);
                double distanceTwo = Math.Pow(Math.Pow(SystemTwoSataliteTwo.OrbitingDistance, 2) + Math.Pow(SystemTwoSataliteOne.OrbitingDistance, 2), 0.5);
                double heightTwo = GetTidalHeight(SystemTwoSataliteOne.Mass, SystemTwoSataliteTwo.Mass, SystemTwoSataliteTwo.Radius, distanceTwo);
                expected = (heightOne + heightTwo) * -0.4;
            }
            if (expected == 1)
            {
                throw new Exception("test error: expected has not been set as the given time has no value setting it");
            }
            mockItemsRepository.Setup(m => m.GetAll()).Returns([SystemTwoStar, SystemTwoSataliteOne, SystemTwoSataliteTwo]);

            var result = sut.TotalTidalHeightAndAngle(SystemTwoSataliteTwo, SystemTwoStar, time);

            Assert.Equal(expected, result.Item2, tolerance);
        }
    }
}
