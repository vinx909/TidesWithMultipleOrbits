using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IWriter
    {
        /// <summary>
        /// returns true if the path can be written to
        /// can't write if the directory doesn't exist
        /// can't write if the file does exist
        /// can't write if already writing to a different file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool CanWriteTo(string path);

        /// <summary>
        /// sets up the file so that it can be written to
        /// can't start writing to a new file until the previous file has been stopped with StopWriting()
        /// </summary>
        /// <param name="path"></param>
        /// <returns>returns true if things are set up correctly and can be written to. false if the file could not be set up correctly</returns>
        public bool StartWriting(string path);

        /// <summary>
        /// completes the writing process so that a different file can be written to
        /// </summary>
        /// <returns>returns true if the process is stopped or no writing was taking place, false if unable to complete writing</returns>
        public bool StopWriting();

        /// <summary>
        /// returns true if the writer is currently writing to a file, or false if it is not and can start writing
        /// </summary>
        /// <returns></returns>
        public bool IsWriting();

        /// <summary>
        /// writes the given text to the file that's being written to
        /// can only be used after using StartWriting(string) and before StopWriting()
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool Write(string text);

        /// <summary>
        /// writes the given text and ends it with a line break to the file that's being written to
        /// can only be used after using StartWriting(string) and before StopWriting()
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool WriteLine(string text);
    }
}
