using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.Writer
{
    public class IsWriting : WriterTestBase
    {
        [Fact]
        public void ReturnsFalse_BeforeInvokingStartWriting()
        {
            var result = sut.IsWriting();

            Assert.False(result);
        }

        [Fact]
        public void ReturnsTrue_AfterInvokingStartWriting_BeforeInvokingStopWriting()
        {
            sut.StartWriting(TempFilePath);
            var result = sut.IsWriting();

            Assert.True(result);
        }

        [Fact]
        public void ReturnsFalse_AfterInvokingStopWriting()
        {
            sut.StartWriting(TempFilePath);
            sut.StopWriting();
            var result = sut.IsWriting();

            Assert.False(result);
        }
    }
}
