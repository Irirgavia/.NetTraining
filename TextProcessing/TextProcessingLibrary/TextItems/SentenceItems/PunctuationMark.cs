namespace TextProcessingLibrary.TextItems.SentenceItems
{
    using System.Collections.Generic;

    public class PunctuationMark : SentenceItem
    {
        public PunctuationMark(List<char> symbols)
            : base(symbols)
        {
            this.Symbols = symbols;
        }
    }
}
