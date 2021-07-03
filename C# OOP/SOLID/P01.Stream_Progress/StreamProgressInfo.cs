using P01.Stream_Progress.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IFile file;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IFile file)
        {
            this.file = file;
        }

        public int CalculateCurrentPercent()
        {
            return (this.file.BytesSent * 100) / this.file.Length;
        }
    }
}
