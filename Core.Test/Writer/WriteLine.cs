using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.Writer
{
    public class WriteLine : WriterTestBase, IDisposable
    {
        const string secondPathAdition = ".SecondFile.tmp";
        const string testStringOne = "First test string.";
        const string testStringTwo = " Second test string.";
        const string linebreak = "\r\n";

        private string SecondPath { get; set; }

        [Fact]
        public void ReturnsFalse_BeforeInvokingStartWriting()
        {
            var result = sut.WriteLine(testStringOne);

            Assert.False(result);
        }

        [Fact]
        public void ReturnsFalse_AfterInvokingStopWriting()
        {
            sut.StartWriting(TempFilePath);
            sut.StopWriting();


            var result = sut.WriteLine(testStringOne);

            Assert.False(result);
        }

        [Fact]
        public void FileNotAltered_AfterInvokingStopWriting()
        {
            sut.StartWriting(TempFilePath);
            sut.StopWriting();
            string origionalFileContent = File.ReadAllText(TempFilePath);

            sut.WriteLine(testStringOne);

            Assert.Equal(origionalFileContent, File.ReadAllText(TempFilePath));
        }

        [Fact]
        public void ReturnsTrue_AfterInvokingStartWriting_BeforeInvokingStopWriting()
        {
            sut.StartWriting(TempFilePath);


            var result = sut.WriteLine(testStringOne);

            Assert.True(result);
        }

        [Fact]
        public void FileCorrectContent_AfterInvokingStartWriting_BeforeInvokingStopWriting()
        {
            sut.StartWriting(TempFilePath);

            sut.WriteLine(testStringOne);

            ForceCloseSUT();

            Assert.Equal(testStringOne + linebreak, File.ReadAllText(TempFilePath));
        }

        [Fact]
        public void FileCorrectContent_AfterInvokingStartWriting_BeforeInvokingStopWriting_SecondTime()
        {
            sut.StartWriting(TempFilePath);

            sut.WriteLine(testStringOne);
            sut.WriteLine(testStringTwo);

            ForceCloseSUT();

            Assert.Equal(testStringOne + linebreak + testStringTwo + linebreak, File.ReadAllText(TempFilePath));
        }

        [Fact]
        public void ReturnsTrue_AfterInvokingStartWriting_BeforeInvokingStopWriting_OnSecondFile()
        {
            sut.StartWriting(TempFilePath);
            sut.StopWriting();
            sut.StartWriting(SecondPath);

            var result = sut.WriteLine(testStringOne);

            Assert.True(result);
        }

        [Fact]
        public void FileCorrectContent_AfterInvokingStartWriting_BeforeInvokingStopWriting_OnSecondFile()
        {
            sut.StartWriting(TempFilePath);
            sut.StopWriting();
            sut.StartWriting(SecondPath);

            sut.WriteLine(testStringOne);

            ForceCloseSUT();

            Assert.Equal(testStringOne + linebreak, File.ReadAllText(SecondPath));
        }

        public WriteLine()
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
