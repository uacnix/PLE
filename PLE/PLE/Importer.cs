using System;
using System.Collections.Generic;
using System.IO;

namespace PLE
{
    internal class Importer
    {
        private string path;
        private int lineCount;
        private int threadCount;
        private int ls, le;
        public Importer(string path,int threads)
        {
            this.path = path;
            threadCount = threads;
        }

        public void Import()
        {
            //TODO: implement thread count selector.
            Console.WriteLine("Log Importer v0.1...");
            lineCount = getLineCount();
            Console.WriteLine("Lines to read: " + lineCount);
            int linePool = lineCount / threadCount;
            Console.WriteLine("Lines per one thread: "+linePool);
            List<ImWorker> workers = new List<ImWorker>();
#if true
            for(int i = 0; i < threadCount; i++)
            {
                ImWorker w;
                if (i != threadCount - 1) {
                    
                    ls = linePool * i;
                    le = linePool * (i + 1)-1;
                    Console.WriteLine("Worker " + i + " gets pool from " + ls+" to "+le +" ("+(le- ls)+" lines)");
                    //w = new ImWorker(path, ls, le);
                }
                else
                {
                    ls = linePool * i;
                    le = lineCount;
                    Console.WriteLine("FINAL Worker " + i + " gets pool from " + ls + " to " + lineCount + " (" + (le - ls) + " lines)");
                    //w = new ImWorker(path, ls, le);
                }
                //workers.Add(w);
            }
#endif
        }

        private int getLineCount()
        {
            return File.ReadAllLines(path).Length;
        }
    }
}