namespace BLL.Parser
{
    using System.Collections.Generic;
    using System.IO;

    public interface ICSVParser
    {
        IEnumerable<List<string>> ParseCSV(StreamReader stream);
    }
}