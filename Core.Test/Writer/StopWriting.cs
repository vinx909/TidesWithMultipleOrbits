using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.Writer
{
    public class StopWriting : WriterTestBase
    {
        [Fact]
        public void ReturnsTrue_IfNotWriting()
        {
            if (sut.IsWriting())
            {
                throw new Exception("sut.IsWriting() returns true while nothing should have been invoked yet which should not be possible and thus indicates something is very wrong");
            }

            var result = sut.StopWriting();

            Assert.True(result);
        }

        [Fact]
        public void ReturnsTrue_IfEndedWriting()
        {
            sut.StartWriting(TempFilePath);

            var result = sut.StopWriting();

            Assert.True(result);
        }
    }
}
