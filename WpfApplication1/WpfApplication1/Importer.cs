using System;
using System.Collections.Generic;

namespace WpfApplication1
{
    internal class Importer
    {
        private string path;
        private int lineCount;
        private int threadCount;
        public Importer(string path,int threads)
        {
            this.path = path;
            threadCount = threads;
        }

        public void Import()
        {
            //TODO: implement thread count selector.
            lineCount = getLineCount();
            int linePool = lineCount / threadCount;
            List<ImWorker> workers = new List<ImWorker>();
            for(int i = 0; i < threadCount; i++)
            {
                ImWorker w;
                if (i!=threadCount-1)
                    w = new ImWorker(path, linePool * i, linePool * (i + 1));
                else
                {
                    w = new ImWorker(path, linePool * i, lineCount);
                }
                workers.Add(w);
            }
        }

        private int getLineCount()
        {
            return null;
        }
    }
}