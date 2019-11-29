namespace TextProcessingLibrary.TextItems.SentenceItems
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Word : SentenceItem
    {
        public Word(List<char> symbols, int locationLine = 1)
            : base(symbols)
        {
            this.Symbols = symbols;
            this.LocationLine = locationLine;
        }

        public int LocationLine { get; set; }
    }
}
