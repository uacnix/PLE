using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PLE
{
    internal class Importer
    {
        private string path;
        private int lineCount;
        private int threadCount;
        private int ls, le;
        public List<string> bigList;
        public ConcurrentBag<List<string>> allLines = new ConcurrentBag<List<string>>();
        public Importer(string path,int threads)
        {
            this.path = path;
            threadCount = threads;
        }

        public void Import()
        {
            //TODO: implement thread count selector.
            Console.WriteLine("Log Importer v0.1... Running on "+threadCount+" threads");
            lineCount = getLineCount();
            Console.WriteLine("Lines to read: " + lineCount);
            int linePool = lineCount / threadCount;
            Console.WriteLine("Lines per one thread: "+linePool);
            List<ImWorker> workers = new List<ImWorker>();
#if true
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < threadCount; i++)
            {
                ImWorker w;
                ls = linePool * i;
                if (i != threadCount - 1) {
                    le = linePool * (i + 1)-1;
                    Console.WriteLine("Worker " + i + " gets pool from " + ls+" to "+le +" ("+(le- ls)+" lines)");
                }
                else
                {
                    le = lineCount;
                    Console.WriteLine("FINAL Worker " + i + " gets pool from " + ls + " to " + lineCount + " (" + (le - ls) + " lines)"); 
                }
                w = new ImWorker(path, ls, le);
                workers.Add(w);
            }
            
            Parallel.ForEach(workers,
                worker => allLines.Add(worker.readLines()));
            bigList = new List<string>();
            foreach(List<string> l in allLines)
            {
                bigList = bigList.Concat(l).ToList();

            }
            watch.Stop();
            var elapsed = watch.ElapsedMilliseconds;
            Console.WriteLine("Freshly created list length:"+allLines.Count+"\nBigList lines:"+bigList.Count+"\nTIME ELAPSED:"+elapsed);
#endif
        }

        private int getLineCount()
        {
            var outp = File.ReadLines(path).Count();
            return outp;
        }
        public void clearTable()
        {
            bigList.Clear();
            allLines = null;
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            System.GC.Collect();
            Console.WriteLine("Cleared Cache list, its size now is:" + bigList.Count);
        }
    }
}