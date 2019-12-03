﻿namespace TextProcessingLibrary.Concordance
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ConcordanceWord
    {
        public ConcordanceWord(string word)
        {
            this.Word = word;
            this.LocationLines = new List<int>();
            this.EntriesCounts = 0;
        }

        public ConcordanceWord(string word, List<int> locationLines)
        {
            this.Word = word;
            this.LocationLines = locationLines;
        }

        public string Word { get; private set; }

        public List<int> LocationLines { get; private set; }

        public int EntriesCounts { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder(this.Word);
            stringBuilder.Append($"  {this.EntriesCounts}:");
            foreach (var locationLine in this.LocationLines)
            {
                var page = locationLine / Constants.LinesCountsPerPage;
                var str = locationLine % Constants.LinesCountsPerPage;

                stringBuilder.Append($" {page}({str}),");
            }

            return stringBuilder.ToString().TrimEnd(',');
        }
    }
}
