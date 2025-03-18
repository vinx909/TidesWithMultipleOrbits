using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.TideCalculator
{
    public class WriteAngleToFile : TideCalculatorTestBase
    {
        [Fact]
        public void ReturnsFalse_WhenSetWritePathNotSet()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            Assert.False(result);
        }

        [Fact]
        public void InvokesIWriterCanWrite()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            sut.SetWritePath(path);

            sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockWriter.Verify(m => m.CanWriteTo(It.IsAny<string>()));
        }

        [Fact]
        public void InvokesIWriterCanWriteWithSetPath()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            sut.SetWritePath(path);

            sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockWriter.Verify(m => m.CanWriteTo(path));
        }

        [Fact]
        public void ReturnsFalse_WhenIWriterCanWriteToReturnsFalse()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            sut.SetWritePath(path);
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(false);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            Assert.False(result);
        }

        [Fact]
        public void InvokesIWriterIsWriting()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            sut.SetWritePath(path);

            sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockWriter.Verify(m => m.IsWriting());
        }

        [Fact]
        public void ReturnsFalse_IWriterIsWritingReturnsTrue()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            sut.SetWritePath(path);
            mockWriter.Setup(m => m.IsWriting()).Returns(true);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            Assert.False(result);
        }

        [Fact]
        public void InvokesIWriterStartWriting()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            sut.SetWritePath(path);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockWriter.Verify(m => m.StartWriting(It.IsAny<string>()));
        }

        [Fact]
        public void InvokesIWriterStartWritingWithSetPath()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            sut.SetWritePath(path);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockWriter.Verify(m => m.CanWriteTo(path));
        }

        [Fact]
        public void ReturnsFalse_WhenIWriterStartWriting_ReturnsFalse()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            sut.SetWritePath(path);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(false);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            Assert.False(result);
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryGetIdOfOrbitItem()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);

            sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockItemsRepository.Verify(m => m.GetIdOf(It.IsAny<Entities.OrbitItem>()));
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryGetIdOfOrbitItemWithGivenItems()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);

            sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockItemsRepository.Verify(m => m.GetIdOf(star));
            mockItemsRepository.Verify(m => m.GetIdOf(sataliteOne));
            mockItemsRepository.Verify(m => m.GetIdOf(sataliteTwo));
        }

        [Fact]
        public void Returnsfalse_WhenItemNotInRange()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);

            mockItemsRepository.Setup(m => m.GetIdOf(It.IsAny<Entities.OrbitItem>())).Returns(value:null);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            Assert.False(result);
        }

        [Fact]
        public void Returnsfalse_WhenItemWithSameId()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteOne.Id);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            Assert.False(result);
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryGetInt_Angle90Degrees()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);

            sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockItemsRepository.Verify(m => m.Get(It.IsAny<int>()));
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryGetIntExpectedAmountsOfTimes_Angle90Degrees()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);

            sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockItemsRepository.Verify(m => m.Get(It.IsAny<int>()), Times.Exactly(3));
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryGetWithReturnedIds_Angle90Degrees()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockItemsRepository.Verify(m => m.Get(star.Id));
            mockItemsRepository.Verify(m => m.Get(sataliteOne.Id));
            mockItemsRepository.Verify(m => m.Get(sataliteTwo.Id));
        }

        [Fact]
        public void ReturnsTrue_WhenAllCorrect()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            Assert.True(result);
        }

        [Fact]
        public void InvokesIWriterWrite()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockWriter.Verify(m => m.Write(It.IsAny<string>()));
        }

        [Fact]
        public void InvokesIWriterWriteCorrectAmountOfTimes()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockWriter.Verify(m => m.Write(It.IsAny<string>()), Times.Exactly(4));
        }

        [Fact]
        public void InvokesIWriterWriteWithCorrectStrings()
        {
            string expectedOne = "0" + Services.TideCalculator.FieldSepertor + Math.Acos(1) + Services.TideCalculator.LineSeperator;
            string expectedTwo = "1" + Services.TideCalculator.FieldSepertor + Math.Acos(0) + Services.TideCalculator.LineSeperator;
            string expectedThree = "2" + Services.TideCalculator.FieldSepertor + Math.Acos(-1) + Services.TideCalculator.LineSeperator;
            string expectedFour = "3" + Services.TideCalculator.FieldSepertor + -Math.Acos(0) + Services.TideCalculator.LineSeperator;
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockWriter.Verify(m => m.Write(expectedOne), Times.Once());
            mockWriter.Verify(m => m.Write(expectedTwo), Times.Once());
            mockWriter.Verify(m => m.Write(expectedThree), Times.Once());
            mockWriter.Verify(m => m.Write(expectedFour), Times.Once());
        }

        [Fact]
        public void InvokesIWriterStopWriting()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockWriter.Verify(m => m.StopWriting());
        }
    }
}
