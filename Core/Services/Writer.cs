using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class Writer : IWriter, IDisposable
    {
        private const char fileFolderSeperator = '\\';

        private StreamWriter? fileWriter;

        public Writer()
        {
            fileWriter = null;
        }

        public void Dispose()
        {
            if (fileWriter != null)
            {
                fileWriter.Dispose();
                fileWriter.Close();
            }
        }

        public bool CanWriteTo(string path)
        {
            return !File.Exists(path) && Directory.Exists(path.Substring(0, path.Length - path.Split(fileFolderSeperator).Last().Length-1));
        }

        public bool IsWriting()
        {
            return fileWriter != null;
        }

        public bool StartWriting(string path)
        {
            if (!IsWriting() && CanWriteTo(path))
            {
                fileWriter = new(path);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool StopWriting()
        {
            if(fileWriter == null)
            {
                return true;
            }
            else
            {
                fileWriter.Dispose();
                fileWriter = null;
                return true;
            }
        }

        public bool Write(string text)
        {
            if(fileWriter != null)
            {
                fileWriter.Write(text);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool WriteLine(string text)
        {
            if (fileWriter != null)
            {
                fileWriter.WriteLine(text);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
