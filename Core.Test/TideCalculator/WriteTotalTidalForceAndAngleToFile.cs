using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.TideCalculator
{
    public class WriteTotalTidalForceAndAngleToFile : TideCalculatorTestBase
    {
        [Fact]
        public void ReturnsFalse_WhenSetWritePathNotSet()
        {
            var star = SystemOneStar;
            var sataliteTwo = SystemOneSataliteTwo;

            var result = sut.WriteTotalTidalForceAndAngleToFile(star, sataliteTwo, 0, 3, 1);

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

            sut.WriteTotalTidalForceAndAngleToFile(star, sataliteTwo, 0, 3, 1);

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

            sut.WriteTotalTidalForceAndAngleToFile(star, sataliteTwo, 0, 3, 1);

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

            var result = sut.WriteTotalTidalForceAndAngleToFile(star, sataliteTwo, 0, 3, 1);

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

            sut.WriteTotalTidalForceAndAngleToFile(star, sataliteTwo, 0, 3, 1);

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

            var result = sut.WriteTotalTidalForceAndAngleToFile(star, sataliteTwo, 0, 3, 1);

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

            var result = sut.WriteTotalTidalForceAndAngleToFile(star, sataliteTwo, 0, 3, 1);

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

            var result = sut.WriteTotalTidalForceAndAngleToFile(star, sataliteTwo, 0, 3, 1);

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

            var result = sut.WriteTotalTidalForceAndAngleToFile(star, sataliteTwo, 0, 3, 1);

            Assert.False(result);
        }

        //todo: IWriter.StopWriting() tests
    }
}
