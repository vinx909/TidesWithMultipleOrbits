using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class Writer : IWriter
    {
        public bool CanWriteTo(string path)
        {
            throw new NotImplementedException();
        }

        public bool IsWriting()
        {
            throw new NotImplementedException();
        }

        public bool StartWriting(string path)
        {
            throw new NotImplementedException();
        }

        public bool StopWriting()
        {
            throw new NotImplementedException();
        }

        public bool Write(string text)
        {
            throw new NotImplementedException();
        }

        public bool WriteLine(string text)
        {
            throw new NotImplementedException();
        }
    }
}
