namespace TextProcessingLibrary
{
    using System;
    using System.IO;

    public class Writer
    {
        private readonly string filePath;

        public Writer(string filePath)
        {
            this.filePath = filePath;
        }

        public void WriteFile(string str)
        {
            using (var sw = new StreamWriter(this.filePath, true))
            {
                sw.Write(str);
            }
        }

        public void WriteConsole(string str)
        {
            Console.WriteLine(str);
        }
    }
}
