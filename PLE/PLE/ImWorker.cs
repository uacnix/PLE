using System.Collections.Generic;
using System.IO;

namespace PLE
{
    internal class ImWorker
    {
        private int lineEnd;
        private string path;
        private int lineStart;

        public ImWorker(string path, int v, int lineCount)
        {
            this.path = path;
            lineStart = v;
            lineEnd = lineCount;
        }
        public List<string> readLines()
        {
            List<string> output = new List<string>();
            string s;
            StreamReader sr = new StreamReader(path);
            for(int i = 0; i < lineStart; i++)
            {
                sr.ReadLine();
            }
            for(int i = lineStart; i < lineEnd; i++)
            {
                output.Add(sr.ReadLine());
            }

            return output;
        }
    }
}