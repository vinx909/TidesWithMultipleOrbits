using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.Writer
{
    public class StartWriting : WriterTestBase, IDisposable
    {
        const string secondPathAdition = ".SecondFile.tmp";

        private string SecondPath { get; set; }

        [Fact]
        public void ReturnsTrue_IfFileDoesNotExist_AndDirectoryDoesExist()
        {
            if (File.Exists(TempFilePath))
            {
                throw new Exception("the TempFilePath points to a file that exists, this should not be possible and will ruin many tests");
            }

            var result = sut.StartWriting(TempFilePath);

            Assert.True(result);
        }

        [Fact]
        public void FileExists_IfFileDoesNotExist_AndDirectoryDoesExist()
        {
            if (File.Exists(TempFilePath))
            {
                throw new Exception("the TempFilePath points to a file that exists, this should not be possible and will ruin many tests");
            }

            var result = sut.StartWriting(TempFilePath);

            Assert.True(File.Exists(TempFilePath));
        }

        [Fact]
        public void FileEmpty_IfFileDoesNotExist_AndDirectoryDoesExist()
        {
            if (File.Exists(TempFilePath))
            {
                throw new Exception("the TempFilePath points to a file that exists, this should not be possible and will ruin many tests");
            }

            sut.StartWriting(TempFilePath);

            ForceCloseSUT();

            Assert.True(File.ReadAllText(TempFilePath).Length==0);
        }

        [Fact]
        public void ReturnsFalse_IfFileExists()
        {
            File.Create(TempFilePath).Dispose();

            var result = sut.StartWriting(TempFilePath);

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

            var result = sut.StartWriting(testPath);

            Assert.False(result);
        }

        [Fact]
        public void FileDoesNotExist_IfDirectoryDoesNotExist()
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

            sut.StartWriting(testPath);

            Assert.False(File.Exists(TempFilePath));
        }

        [Fact]
        public void ReturnsFalse_IfAlreadyWriting()
        {
            sut.StartWriting(TempFilePath);

            var result = sut.StartWriting(SecondPath);

            Assert.False(result);
        }

        [Fact]
        public void FileDoesNotExist_IfAlreadyWriting()
        {
            sut.StartWriting(TempFilePath);

            sut.StartWriting(TempFilePath);

            Assert.False(File.Exists(SecondPath));
        }

        [Fact]
        public void ReturnsTrue_IfNewFileAfterInvokingStopWriting()
        {
            sut.StartWriting(TempFilePath);
            sut.StopWriting();

            var result = sut.StartWriting(SecondPath);

            Assert.True(result);
        }

        [Fact]
        public void FileExists_IfNewFileAfterInvokingStopWriting()
        {
            sut.StartWriting(TempFilePath);
            sut.StopWriting();

            var result = sut.StartWriting(SecondPath);

            Assert.True(File.Exists(SecondPath));
        }

        [Fact]
        public void FileEmpty_IfNewFileAfterInvokingStopWriting()
        {
            sut.StartWriting(TempFilePath);
            sut.StopWriting();

            sut.StartWriting(SecondPath);

            ForceCloseSUT();

            Assert.True(File.ReadAllText(SecondPath).Length == 0);
        }

        public StartWriting()
        {
            SecondPath = TempFilePath + secondPathAdition;
        }

        public new void Dispose()
        {
            ForceCloseSUT();

            if (File.Exists(SecondPath))
            {
                File.Delete(SecondPath);
            }

            base.Dispose();
        }
    }
}
