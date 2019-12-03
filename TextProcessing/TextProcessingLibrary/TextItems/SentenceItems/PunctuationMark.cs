namespace TextProcessingLibrary.TextItems.SentenceItems
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class PunctuationMark : SentenceItem
    {
        public PunctuationMark(List<char> symbols)
            : base(symbols)
        {
            this.Symbols = symbols;
        }
    }
}
