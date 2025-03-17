using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.Writer
{
    public class Write : WriterTestBase, IDisposable
    {
        const string secondPathAdition = ".SecondFile.tmp";
        const string testStringOne = "First test string.";
        const string testStringTwo = " Second test string.";

        private string SecondPath { get; set; }

        [Fact]
        public void ReturnsFalse_BeforeInvokingStartWriting()
        {
            var result = sut.Write(testStringOne);

            Assert.False(result);
        }

        [Fact]
        public void ReturnsFalse_AfterInvokingStopWriting()
        {
            sut.StartWriting(TempFilePath);
            sut.StopWriting();


            var result = sut.Write(testStringOne);

            Assert.False(result);
        }

        [Fact]
        public void FileNotAltered_AfterInvokingStopWriting()
        {
            sut.StartWriting(TempFilePath);
            sut.StopWriting();
            string origionalFileContent = File.ReadAllText(TempFilePath);

            sut.Write(testStringOne);

            Assert.Equal(origionalFileContent, File.ReadAllText(TempFilePath));
        }

        [Fact]
        public void ReturnsTrue_AfterInvokingStartWriting_BeforeInvokingStopWriting()
        {
            sut.StartWriting(TempFilePath);


            var result = sut.Write(testStringOne);

            Assert.True(result);
        }

        [Fact]
        public void FileNotTheSame_AfterInvokingStartWriting_BeforeInvokingStopWriting()
        {
            sut.StartWriting(TempFilePath);
            string origionalFileContent = File.ReadAllText(TempFilePath);

            sut.Write(testStringOne);

            Assert.NotEqual(origionalFileContent, File.ReadAllText(TempFilePath));
        }

        [Fact]
        public void FileCorrectContent_AfterInvokingStartWriting_BeforeInvokingStopWriting()
        {
            sut.StartWriting(TempFilePath);

            sut.Write(testStringOne);

            Assert.Equal(testStringOne, File.ReadAllText(TempFilePath));
        }

        [Fact]
        public void FileCorrectContent_AfterInvokingStartWriting_BeforeInvokingStopWriting_SecondTime()
        {
            sut.StartWriting(TempFilePath);

            sut.Write(testStringOne);
            sut.Write(testStringTwo);

            Assert.Equal(testStringOne+testStringTwo, File.ReadAllText(TempFilePath));
        }

        [Fact]
        public void ReturnsTrue_AfterInvokingStartWriting_BeforeInvokingStopWriting_OnSecondFile()
        {
            sut.StartWriting(TempFilePath);
            sut.StopWriting();
            sut.StartWriting(SecondPath);

            var result = sut.Write(testStringOne);

            Assert.True(result);
        }

        [Fact]
        public void FileNotTheSame_AfterInvokingStartWriting_BeforeInvokingStopWriting_OnSecondFile()
        {
            sut.StartWriting(TempFilePath);
            sut.StopWriting();
            sut.StartWriting(SecondPath);
            string origionalFileContent = File.ReadAllText(TempFilePath);

            sut.Write(testStringOne);

            Assert.NotEqual(origionalFileContent, File.ReadAllText(TempFilePath));
        }

        [Fact]
        public void FileCorrectContent_AfterInvokingStartWriting_BeforeInvokingStopWriting_OnSecondFile()
        {
            sut.StartWriting(TempFilePath);
            sut.StopWriting();
            sut.StartWriting(SecondPath);

            sut.Write(testStringOne);

            Assert.Equal(testStringOne, File.ReadAllText(TempFilePath));
        }

        public Write()
        {
            SecondPath = TempFilePath + secondPathAdition;
        }

        public new void Dispose()
        {
            if (File.Exists(SecondPath))
            {
                File.Delete(SecondPath);
            }

            base.Dispose();
        }
    }
}
