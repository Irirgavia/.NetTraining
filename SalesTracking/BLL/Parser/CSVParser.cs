namespace BLL.Parser
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using BLL.Parser;

    public class CSVParser : ICSVParser
    {
        public IEnumerable<List<string>> ParseCSV(StreamReader stream)
        {
            var components = new List<string>();

            while (stream.Peek() != -1)
            {
                var str = stream.ReadLine();
                components = str.Split(new char[] { ';' }).ToList();
                yield return components;
            }
        }
    }
}
