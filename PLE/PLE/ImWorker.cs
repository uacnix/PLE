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
            this.lineStart = v;
            this.lineEnd = lineCount;
        }
    }
}