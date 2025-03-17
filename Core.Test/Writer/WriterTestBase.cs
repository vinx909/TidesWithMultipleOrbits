using Service = Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Core.Test.Writer
{
    public class WriterTestBase : IDisposable
    {
        private static Random Random = new Random();

        private const string fileName = "TidesWithMulitpleOrbits.Core.Test.WriterTest{0}.tmp";

        protected string TempFilePath { get; private set; }

        protected IWriter sut;

        public WriterTestBase()
        {
            int fileNumber = 0;
            do
            {
                fileNumber += Random.Next(100);
                TempFilePath = Path.GetTempPath() + string.Format(fileName, fileNumber);
            }
            while (File.Exists(TempFilePath));

            sut = new Service.Writer();
        }

        public void Dispose()
        {
            if (File.Exists(TempFilePath))
            {
                File.Delete(TempFilePath);
            }
        }
    }
}
