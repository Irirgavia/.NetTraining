namespace BLL.Writer
{
    using System;
    using System.IO;

    public class FileWriter : IWriter
    {
        private string filePath;

        public FileWriter(string filePath)
        {
            this.filePath = filePath;
        }

        public void Write(string str)
        {
            using (var sw = new StreamWriter(filePath, true))
            {
                sw.Write(str);
            }
        }

        public void WriteLine(string str)
        {
            using (var sw = new StreamWriter(filePath, true))
            {
                sw.Write($"{str}{Environment.NewLine}");
            }
        }
    }
}