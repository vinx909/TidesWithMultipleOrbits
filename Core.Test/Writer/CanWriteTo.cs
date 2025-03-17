using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.Writer
{
    public class CanWriteTo : WriterTestBase
    {
        [Fact]
        public void ReturnsTrue_IfFileDoesNotExist_AndDirectoryDoesExist()
        {
            if (File.Exists(TempFilePath))
            {
                throw new Exception("the TempFilePath points to a file that exists, this should not be possible and will ruin many tests");
            }

            var result = sut.CanWriteTo(TempFilePath);

            Assert.True(result);
        }

        [Fact]
        public void ReturnsFalse_IfFileExists()
        {
            File.Create(TempFilePath).Dispose();

            var result = sut.CanWriteTo(TempFilePath);

            Assert.False(result);
        }

        [Fact]
        public void ReturnsFalse_IfDirectoryDoesNotExist()
        {
            const string notExistingDirectory = "\\notExistingFolder";
            const string notExistingFile = "\\not existing file";

            if (File.Exists(TempFilePath))
            {
                throw new Exception("the TempFilePath points to a file that exists, this should not be possible and will ruin many tests");
            }
            string testPath = Path.GetTempPath() + notExistingDirectory;
            if (Directory.Exists(testPath))
            {
                throw new Exception("the directory " + testPath + " exists, which it shouldn't and thus ruins this test");
            }
            testPath += notExistingFile;

            var result = sut.CanWriteTo(TempFilePath);

            Assert.False(result);
        }
    }
}
