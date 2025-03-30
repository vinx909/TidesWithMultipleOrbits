using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.TideCalculator
{
    public class SetWritePath : TideCalculatorTestBase
    {
        [Fact]
        public void CallsIWriterIsWriting()
        {
            sut.SetWritePath(path);

            mockWriter.Verify(m => m.IsWriting());
        }

        [Fact]
        public void ReturnsFalse_WhenIWriterIsWritingReturnsTrue()
        {
            mockWriter.Setup(m => m.IsWriting()).Returns(true);

            var result = sut.SetWritePath(path);

            Assert.False(result);
        }

        [Fact]
        public void CallsIWriterCanWriteTo()
        {
            mockWriter.Setup(m => m.IsWriting()).Returns(false);

            sut.SetWritePath(path);

            mockWriter.Verify(m => m.CanWriteTo(It.IsAny<string>()));
        }

        [Fact]
        public void CallsIWriterCanWriteToWithCorrectPath()
        {
            mockWriter.Setup(m => m.IsWriting()).Returns(false);

            sut.SetWritePath(path);

            mockWriter.Verify(m => m.CanWriteTo(path));
        }

        [Fact]
        public void ReturnsFalse_WhenIWriterCanWriteToReturnsFalse()
        {
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.CanWriteTo(It.IsAny<string>())).Returns(false);

            var result = sut.SetWritePath(path);

            Assert.False(result);
        }

        [Fact]
        public void ReturnsTrue_WhenPathCorrect()
        {
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);

            var result = sut.SetWritePath(path);

            Assert.True(result);
        }
    }
}
